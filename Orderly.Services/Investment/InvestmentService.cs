using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;

using Orderly.Core.Domain.Investment;
using Orderly.Core.Domain.Portfolio;
using Orderly.Models.Comman;
using Orderly.Models.Enums;
using Orderly.Models.Investment;
using Orderly.Models.ViewModels;
using Orderly.Repositories;
using Orderly.Services.User;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderly.Services.Investment
{
    public class InvestmentService : IInvestmentService
    {
        #region Properties
        private readonly IRepository<UserInvestment> _userInvestmentRepository;
        private readonly IRepository<MonitoringType> _monitoringRepository;
        private readonly IRepository<InvestmentDynamicDistribution> _investmentDynamicDistributionRepository;
        private readonly IRepository<SharedInvestmentDetails> _sharedInvestmentDetails;
        private readonly IApplicationUser _appUser;
        #endregion

        #region Constructor
        public InvestmentService(IRepository<UserInvestment> userInvestmentRepository,
            IRepository<MonitoringType> monitoringRepository,
            IApplicationUser appUser,
            IRepository<InvestmentDynamicDistribution> investmentDynamicDistributionRepository,
            IRepository<SharedInvestmentDetails> sharedInvestmentDetails)
        {
            _userInvestmentRepository = userInvestmentRepository;
            _monitoringRepository = monitoringRepository;
            _appUser = appUser;
            _investmentDynamicDistributionRepository = investmentDynamicDistributionRepository;
            _sharedInvestmentDetails = sharedInvestmentDetails;
        }
        #endregion

        #region Methods
        public async Task DeleteInvestmentAsync(int userId, int investmentId)
        {
            var investment = await GetByIdAndUserId(userId, investmentId);
            if (investment != null)
            {
                await _userInvestmentRepository.DeleteAsync(investment);
            }
        }

        public async Task<UserInvestment> GetById(int id)
        {
            return await (await _userInvestmentRepository.GetAllAsync(x => x.Id == id)).Include(x => x.DynamicDistributions).FirstOrDefaultAsync();
        }

        public async Task<UserInvestment> GetInvestmentByGUIDAsync(Guid investmentGUID)
        {
            return await (await _userInvestmentRepository.GetAllAsync(x => x.InvestmentGUID == investmentGUID)).FirstOrDefaultAsync();
        }

        public async Task<UserInvestment> GetByIdAndUserId(int userId, int investmentId)
        {
            return await (await _userInvestmentRepository.GetAllAsync(x => x.User.Id == userId && x.Id == investmentId)).Include(x => x.DynamicDistributions).Include(x=>x.sharedInvestmentDetails).ThenInclude(y=>y.Contact).FirstOrDefaultAsync();
        }

        public async Task<IList<UserInvestment>> GetInvestmentsByUserIdAsync(int userId)
        {
            return await (await _userInvestmentRepository.GetAllAsync(x => x.User.Id == userId)).Include(x=>x.sharedInvestmentDetails).ToListAsync();
        }

        public async Task<int> InsertOrUpdateInvestmentAsync(UserInvestmentModel model)
        {
            UserInvestment userInvestment = null;
            if (model.UniqueInvestmentId != null)
            {
                var investment = await GetInvestmentByGUIDAsync(model.UniqueInvestmentId.Value);
                investment.UpdatedOnDateTimeUTC = DateTime.UtcNow;
                investment.VestingId = model.VestingId;
                investment.VestingLockup = model.VestingLockup;
                investment.VestingTokenPercentage = model.VestingTokenPercentage;
                investment.WebsiteLink = model.WebsiteLink;
                investment.DistributionTypeId = model.DistributionTypeId;
                investment.InvestedAmount = model.InvestedAmount;
                investment.InvestmentTransactionLink = model.InvestmentTransactionLink;
                investment.InvestmentTypeId = model.InvestmentTypeId;
                investment.MonitoringType = await _monitoringRepository.GetByIdAsync(model.NetworkId);
                //investment.SaftFile = model.SaftFile;
                investment.CustomLink = model.CustomLink;
                investment.DistributionPortal = model.DistributionPortal;
                investment.Sign = model.Sign;
                investment.ContactId = model.Sign == null ? model.ContactId : null;
                userInvestment = investment;
                investment.InvestedQuantity = model.InvestmentQuantity;
                investment.TokenId = model.TokenId;
                investment.NumberOfToken = model.NumberOfToken;
                investment.SentAddressFrom = model.FromAddress;
                await _userInvestmentRepository.UpdateAsync(investment);
            }
            else
            {
                var currentUser = await _appUser.GetCurrentUserAsync();
                if (currentUser != null)
                {
                    userInvestment = new UserInvestment()
                    {
                        CreatedOnDateTimeUTC = DateTime.UtcNow,
                        DistributionTypeId = model.DistributionTypeId,
                        InvestedAmount = model.InvestedAmount,
                        InvestmentGUID = Guid.NewGuid(),
                        InvestmentTransactionLink = model.InvestmentTransactionLink,
                        InvestmentTypeId = model.InvestmentTypeId,
                        MonitoringType = _monitoringRepository.GetByIdAsync(model.NetworkId).Result,
                        UpdatedOnDateTimeUTC = DateTime.UtcNow,
                        User = currentUser,
                        VestingId = model.VestingId,
                        VestingLockup = model.VestingLockup,
                        VestingTokenPercentage = model.VestingTokenPercentage,
                        WebsiteLink = model.WebsiteLink,
                        CustomLink = model.CustomLink,
                        DistributionPortal = model.DistributionPortal,
                        Sign = model.Sign,
                        ContactId = model.Sign == null ? model.ContactId : null,
                        InvestedQuantity = model.InvestmentQuantity,
                        TokenId = model.TokenId,
                        NumberOfToken = model.NumberOfToken,
                        SentAddressFrom = model.FromAddress
                };
                    await _userInvestmentRepository.InsertAsync(userInvestment);
                    model.Id = userInvestment.Id;
                    model.UniqueInvestmentId = userInvestment.InvestmentGUID;
                }
            }
            await InsertOrUpdateInvestmentGroupDetails(model.Address, userInvestment.Id);
            await InsertOrUpdateDynamicDistributionAsync(model, userInvestment);
            return model.Id;
        }

        public async Task InsertOrUpdateInvestmentGroupDetails(string sharedDetails, int id)
        {
            try
            {
                var sharedInvestmentDetails = JsonConvert.DeserializeObject<IList<InvestmentSharedDetailViewModel>>(sharedDetails);
                if(sharedInvestmentDetails.Count > 0)
                {
                    var existingDetails = (await _sharedInvestmentDetails.GetAllAsync(x => x.InvestmentId == id)).ToList();
                    if (existingDetails.Any())
                    {
                        await _sharedInvestmentDetails.DeleteAllAsync(existingDetails);
                    }

                    foreach (var detail in sharedInvestmentDetails)
                    {
                        if(detail.ContactId > 0)
                        {
                            await _sharedInvestmentDetails.InsertAsync(new SharedInvestmentDetails()
                            {
                                InvestmentId = id,
                                ContactId = detail.ContactId,
                                Percentage = Convert.ToDecimal(detail.SharedPercentage)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        public async Task InsertOrUpdateDynamicDistributionAsync(UserInvestmentModel model, UserInvestment userInvestment = null)
        {
            try
            {
                var dynamicDistributions = JsonConvert.DeserializeObject<IList<DistributionTypeModel>>(model.Disributions);
                if (dynamicDistributions.Count > 0)
                {
                    if (model.Id > 0)
                    {
                        var dist = (await _investmentDynamicDistributionRepository.GetAllAsync(x => x.Investment.Id == model.Id)).ToList();
                        await _investmentDynamicDistributionRepository.DeleteAllAsync(dist);
                    }

                    foreach (var distribution in dynamicDistributions)
                    {
                        await _investmentDynamicDistributionRepository.InsertAsync(new InvestmentDynamicDistribution()
                        {
                            Investment = userInvestment ?? GetInvestmentByGUIDAsync(model.UniqueInvestmentId.Value).Result,
                            Lookup = distribution.Lockup,
                            LookupDuration = distribution.LockupDuration,
                            Peroid = distribution.Peroid,
                            TGE = distribution.TGE,
                            TokenPercentage = distribution.TokenPercentage
                        });
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        public async Task<IPagedList<UserInvestment>> GetInvestmentListByUserIdAsync(int userId, int pageIndex, int pageSize, int filterType = 0, int filterValue = 0,string keyword = "")
        {
            IQueryable<UserInvestment> userInvestment = (await _userInvestmentRepository.GetAllAsync(x => x.User.Id == userId))
                .Include(x => x.MonitoringType)
                .Include(x=>x.sharedInvestmentDetails)
                .ThenInclude(y=>y.Contact)
                .OrderByDescending(x => x.Id);

            switch (filterType)
            {
                case (int)AnalyzerFilter.Address:
                    var investmentIds = await (await _sharedInvestmentDetails.GetAllAsync(x => x.ContactId == filterValue)).Select(x=>x.Id).ToListAsync();
                    userInvestment = userInvestment.Where(x => investmentIds.Contains(x.Id));
                    break;
                case (int)AnalyzerFilter.Network:
                    userInvestment = userInvestment.Where(x => x.MonitoringTypeId == filterValue);
                    break;
                case (int)AnalyzerFilter.Token:
                    //var ids = await (await _investmentTokenRepository.GetAllAsync(x => x.TokenId == filterValue)).Select(x=>x.InvestmentId).ToListAsync();
                    //userInvestment = userInvestment.Where(x => ids.Contains(x.Id));
                    break;
                default:
                    break;
            }
          
            try
            {
                if (!string.IsNullOrEmpty(keyword))
                {
                    keyword = keyword.ToLower().Trim();
                    userInvestment = userInvestment.Where(x => x.MonitoringType.Abbreviation.ToLower().Contains(keyword)
                    || x.MonitoringType.Type.ToLower().Contains(keyword)
                    || x.VestingLockup.ToString().Contains(keyword)
                    || x.VestingLockup.ToString().Replace(".", "").Contains(keyword)
                    || x.InvestedAmount.ToString().Contains(keyword)
                    || x.InvestedAmount.ToString().Replace(".", "").Contains(keyword)
                    //|| x.investmentTokens.Any(y=>y.networkTokens.Name.ToLower().Contains(keyword))
                    || x.CreatedOnDateTimeUTC.Day.ToString().Contains(keyword)
                    || x.CreatedOnDateTimeUTC.Month.ToString().Contains(keyword)
                    || x.CreatedOnDateTimeUTC.Year.ToString().Contains(keyword)
                    || x.sharedInvestmentDetails.Any(y=>y.Contact.Address.ToLower() == keyword)
                    );
                }
            }
            catch (Exception ex)
            {
                var tesast = ex.Message;
            }
            return await userInvestment.ToPagedListAsync(pageIndex, pageSize);
        }

        public async Task Delete(int id)
        {
            var userInvestment = await _userInvestmentRepository.GetByIdAsync(id);
            var dynamicDistribution = await _investmentDynamicDistributionRepository.GetAllAsync(x => x.Investment.Id == id);
            await _investmentDynamicDistributionRepository.DeleteAllAsync(dynamicDistribution.ToList());
            await _userInvestmentRepository.DeleteAsync(userInvestment);
        }

        public async Task UpdateRefundAmount(RefundModel refundModel)
        {
            var userInvestment = await _userInvestmentRepository.GetByIdAsync(refundModel.Id);
            userInvestment.RefundAmount = Convert.ToDecimal(userInvestment.RefundAmount) + refundModel.RefundAmount;
            await _userInvestmentRepository.UpdateAsync(userInvestment);
        }

        public async Task UpdateSaftFile(string fileName, string uniqueFileName, int id)
        {
            var userInvestment = await _userInvestmentRepository.GetByIdAsync(id);
            userInvestment.SaftFile = fileName;
            userInvestment.SaftPathSavedFileName = uniqueFileName;
            await _userInvestmentRepository.UpdateAsync(userInvestment);
        }

        public async Task<IList<UserInvestment>> GetInvestmentsByUserIdAndTokenAsync(int userId, int tokenId)
        {
            List<UserInvestment> userInvestments = new List<UserInvestment>();
            if (tokenId > 0)
            {
                userInvestments = await (await _userInvestmentRepository.GetAllAsync(x => x.User.Id == userId && (x.TokenId == tokenId || x.TokenId == null))).Include(x => x.sharedInvestmentDetails).ToListAsync();
            }
            else
            {
                userInvestments = await (await _userInvestmentRepository.GetAllAsync(x => x.User.Id == userId && x.TokenId == null)).Include(x => x.sharedInvestmentDetails).ToListAsync();
            }
            return userInvestments;
        }

        public async Task<bool> isTokenAssociated(int tokenId)
        {
            bool isAssociated = false;
            var investment = (await _userInvestmentRepository.GetAllAsync(x => x.TokenId == tokenId)).FirstOrDefault();
            if(investment != null)
            {
                isAssociated = true;
            }
            return isAssociated;
        }

        public async Task<List<UserInvestment>> GetInvestmentsByUserIdAndNetworkIds(int userId, List<int> networkIds)
        {
            return await (await _userInvestmentRepository.GetAllAsync(x => x.User.Id == userId && networkIds.Contains(x.MonitoringTypeId)))
                .Include(x=>x.MonitoringType)
                .ToListAsync();
        }
        #endregion
    }
}
