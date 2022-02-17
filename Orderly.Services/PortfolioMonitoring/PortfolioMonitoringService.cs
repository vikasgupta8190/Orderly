
using Orderly.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orderly.Core.Domain.Investment;
using Orderly.Core.Domain.Portfolio;
using Microsoft.EntityFrameworkCore;
using Orderly.Models.Portfolio;
using Microsoft.AspNetCore.Identity;
using Orderly.Services.User;
using Orderly.Models.Enums;

namespace Orderly.Services.Portfolio
{
    public class PortfolioMonitoringService : IPortfolioMonitoringService
    {
        #region Properties
        private readonly IRepository<PortfolioMonitoring> _portFolioMonitoringRepository;
        private readonly IRepository<MonitoringType> _monitoringtypeRepository;
        private readonly IApplicationUser _appUser;
        #endregion
        #region Constructor
        public PortfolioMonitoringService(IRepository<PortfolioMonitoring> portFolioMonitoringRepository,
            IRepository<MonitoringType> monitoringtypeRepository,
            IApplicationUser appUser
            )
        {
            _portFolioMonitoringRepository = portFolioMonitoringRepository;
            _monitoringtypeRepository = monitoringtypeRepository;
            _appUser = appUser;
        }
        #endregion
        #region Methods
        public async Task DeleteAddressToTableAsync(int addressId, int userId)
        {
            var address = await _portFolioMonitoringRepository.GetByIdAsync(addressId);
            if (address != null && address.User.Id == userId)
            {
                await _portFolioMonitoringRepository.DeleteAsync(address);
            }
        }

        public async Task AddOrUpdateAddressToTableAsync(List<PortFolioMonitoringModel> monitoringModel)
        {
            var currentUser = await _appUser.GetCurrentUserAsync();
            foreach (var values in monitoringModel)
            {
                if (values.Id > 0) //updating values
                {
                    var monitoring = await _portFolioMonitoringRepository.GetByIdAsync(values.Id);
                    if (monitoring != null)
                    {
                        monitoring.AddressAlias = values.AddressAlies;
                        monitoring.Address = values.Address;
                        await _portFolioMonitoringRepository.UpdateAsync(monitoring);

                        if (values.IsSameAddressForBNB)
                        {
                            var existingBNBAddress = (await _portFolioMonitoringRepository
                                .GetAllAsync(x => x.Address == values.Address && x.MonitoringType.Id == Convert.ToInt32(MonitoringTypes.Binance))).FirstOrDefault();
                            if(existingBNBAddress != null)
                            {
                                existingBNBAddress.AddressAlias = values.AddressAlies;
                                existingBNBAddress.Address = values.Address;
                                await _portFolioMonitoringRepository.UpdateAsync(existingBNBAddress);
                            }
                            else
                            {
                                await _portFolioMonitoringRepository.InsertAsync(new PortfolioMonitoring()
                                {
                                    Address = values.Address,
                                    AddressAlias = values.AddressAlies,
                                    MonitoringType = await _monitoringtypeRepository.GetByIdAsync(Convert.ToInt32(MonitoringTypes.Binance)),
                                    User = currentUser
                                });
                            }
                        }
                    }
                }
                else //inserting values
                {
                    if (currentUser != null)
                    {
                        await _portFolioMonitoringRepository.InsertAsync(new PortfolioMonitoring()
                        {
                            Address = values.Address,
                            AddressAlias = values.AddressAlies,
                            MonitoringType = await _monitoringtypeRepository.GetByIdAsync(values.TypeId),
                            User = currentUser
                        });

                        if (values.IsSameAddressForBNB)
                        {
                            await _portFolioMonitoringRepository.InsertAsync(new PortfolioMonitoring()
                            {
                                Address = values.Address,
                                AddressAlias = values.AddressAlies,
                                MonitoringType = await _monitoringtypeRepository.GetByIdAsync(Convert.ToInt32(MonitoringTypes.Binance)),
                                User = currentUser
                            });
                        }
                    }
                }
            }
        }

        public async Task<List<PortfolioMonitoring>> GetAddressesByMonitoringTypeIdAsync(int id, int currentUserId)
        {
            return await (await _portFolioMonitoringRepository.GetAllAsync(x => x.MonitoringType.Id == id && x.User.Id == currentUserId)).ToListAsync();
        }

        public async Task<List<MonitoringType>> GetAllMonitoringTypesAsync(int? typeId = null)
        {
            if (typeId.HasValue)
                return await (await _monitoringtypeRepository.GetAllAsync(x => x.Id == typeId.Value)).ToListAsync();
            return await (await _monitoringtypeRepository.GetAllAsync()).ToListAsync();
        }

        public async Task<List<PortfolioMonitoring>> GetAllAddressesByUserIdAsync(int userId)
        {
            return await (await _portFolioMonitoringRepository.GetAllAsync()).AsQueryable()
                .Include(x => x.User)
                .Include(x => x.MonitoringType)
                .Include(x=>x.Monitoring)
                .Where(x => x.User.Id == userId).ToListAsync();
        }
        #endregion
    }
}
