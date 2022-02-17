using Microsoft.EntityFrameworkCore;

using Orderly.Core.Domain.OverTheCounter;
using Orderly.Models.Comman;
using Orderly.Models.OTC;
using Orderly.Repositories;
using Orderly.Services.User;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orderly.Services.OverTheCounter
{
    public class OTCService : IOTCService
    {
        #region Properties
        private readonly IRepository<OTC> _otcRepository;
        private readonly IApplicationUser _appUser;
        #endregion

        #region Constructor
        public OTCService(IRepository<OTC> otcRepository,
            IApplicationUser appUser)
        {
            _otcRepository = otcRepository;
            _appUser = appUser;
        }       
        #endregion

        #region Methods
        public async Task<IList<OTC>> GetAll()
        {
            return await (await _otcRepository.GetAllAsync()).ToListAsync();
        }

        public async Task<IPagedList<OTC>> GetAll(int userId, int pageIndex, int pageSize)
        {
            return await (await _otcRepository.GetAllAsync(x => x.CreatedByUserId == userId && !x.IsArchive)).Include(x=>x.networkTokens).ToPagedListAsync(pageIndex, pageSize);
        }

        public async Task<OTC> GetById(int Id)
        {
            return await _otcRepository.GetByIdAsync(Id);
        }

        public async Task InsertOrUpdateOTC(OTCModel otcModel)
        {
            if (otcModel.Id > 0)
            {
                var otc = await GetById(otcModel.Id);
                otc.Lockup = otcModel.Lockup;
                otc.PricePerToken = otcModel.PricePerToken;
                otc.TelegramUsername = otcModel.TelegramUsername;
                otc.TokenId = otcModel.TokenId;
                otc.TokenQty = otcModel.TokenQty;
                otc.TotalAmount = otcModel.TotalAmount;
                otc.Vesting = otcModel.Vesting;
                otc.Type = otcModel.Type;
                otc.ContactDetails = otcModel.ContactDetails;
                otc.Email = otcModel.Email;
                await _otcRepository.UpdateAsync(otc);
            }
            else
            {
                var currentUser = await _appUser.GetCurrentUserAsync();
                await _otcRepository.InsertAsync(new OTC()
                {
                    ContactDetails = otcModel.ContactDetails,
                    CreatedOnDateTimeUTC = DateTime.UtcNow,
                    Currency = otcModel.Currency,
                    Email = otcModel.Email,
                    Lockup = otcModel.Lockup,
                    TokenId = otcModel.TokenId,
                    PricePerToken = otcModel.PricePerToken,
                    TelegramUsername = otcModel.TelegramUsername,
                    TokenQty = otcModel.TokenQty,
                    TotalAmount = otcModel.TotalAmount,
                    Type = otcModel.Type,
                    Vesting = otcModel.Vesting,
                    CreatedByUserId = currentUser.Id
                });
            }

        }

        public async Task ArchiveOTC(int hours)
        {
            DateTime fromDate = DateTime.UtcNow.AddHours(-hours);
            var otc = await(await _otcRepository.GetAllAsync(x=>x.CreatedOnDateTimeUTC.Date <= fromDate.Date && !x.IsArchive)).ToListAsync();
            otc.ForEach(x => x.IsArchive = true);
            await _otcRepository.UpdateAllAsync(otc);
        }

        public async Task<List<int>> GetAssignedTokenIds(int userId)
        {
            return await (await _otcRepository.GetAllAsync(x => !x.IsArchive && x.CreatedByUserId == userId)).Select(x => x.TokenId).ToListAsync();
        }

        #endregion
    }
}
