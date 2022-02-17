using Orderly.Models.Portfolio;
using Orderly.Services.Portfolio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orderly.Factories.Portfolio
{
    public class PortfolioModelFactory : IPortfolioModelFactory
    {
        #region Properties
        private readonly IPortfolioMonitoringService _portfolioMonitoringService;
        #endregion

        #region Constructor
        public PortfolioModelFactory(IPortfolioMonitoringService portfolioMonitoringService)
        {
            _portfolioMonitoringService = portfolioMonitoringService;
        }
        #endregion

        #region Methods
        public async Task<List<PortfolioMonitoringType>> PreparePortfolioMonitoringTypesModelAsync(int currentUserId, int? type, string searchKey = null)
        {
            var retVal = new List<PortfolioMonitoringType>();
            var types = await _portfolioMonitoringService.GetAllMonitoringTypesAsync(type);
            if (!string.IsNullOrEmpty(searchKey))
                types = types.Where(x => x.Type.ToLower().Contains(searchKey.ToLower()) || x.Abbreviation.ToLower().Contains(searchKey.ToLower())).ToList();
            if (types.Count > 0)
            {
                retVal = types.Select(x => new PortfolioMonitoringType()
                {
                    Id = x.Id,
                    Name = x.Type,
                    Abbreviation = x.Abbreviation,
                    Icon = x.Icon,
                    Addresses = GetAddressesAsync(x.Id, currentUserId).Result
                }).ToList();
            }
            return retVal;
        }
        #endregion

        #region Utilities
        private async Task<List<PortfolioMonitoringAddress>> GetAddressesAsync(int id, int currentUserId)
        {
            var addressList = await _portfolioMonitoringService.GetAddressesByMonitoringTypeIdAsync(id, currentUserId);
            var retVal = new List<PortfolioMonitoringAddress>();
            if (addressList.Count > 0)
            {
                retVal = addressList.Select(x => new PortfolioMonitoringAddress()
                {
                    Address = x.Address,
                    Alies = x.AddressAlias,
                    Id = x.Id
                }).ToList();
            }
            return retVal;
        }
        #endregion
    }
}
