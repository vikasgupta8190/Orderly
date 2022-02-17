using Microsoft.AspNetCore.Mvc.Rendering;
using Orderly.Models.Comman;
using Orderly.Models.Enums;
using Orderly.Models.Extensions;
using Orderly.Models.Investment;
using Orderly.Models.ViewModels;
using Orderly.Services.Contact;
using Orderly.Services.Investment;
using Orderly.Services.Portfolio;
using Orderly.Services.Token;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orderly.Factories.Investment
{
    public class InvestmentModelFactory : IInvestmentModelFactory
    {
        #region Properties
        private readonly IInvestmentService _investmentService;
        private readonly IPortfolioMonitoringService _portfolioMonitoringService;
        private readonly IContactService _contactService;
        private readonly INetworkTokenService _tokenService;
        #endregion

        #region Constructor
        public InvestmentModelFactory(
            IInvestmentService investmentService,
            IPortfolioMonitoringService portfolioMonitoringService,
            IContactService contactService,
            INetworkTokenService tokenService)
        {
            _investmentService = investmentService;
            _portfolioMonitoringService = portfolioMonitoringService;
            _contactService = contactService;
            _tokenService = tokenService;
        }
        #endregion

        #region Methods
        public async Task<UserInvestmentModel> PrepareUserInvestmentModelAsync(int userId, int investmentId = 0)
        {
            var userInvestment = await _investmentService.GetByIdAndUserId(userId, investmentId);
            var retVal = new UserInvestmentModel();
            retVal.UserId = userId;
            if (userInvestment != null)
            {
                retVal.DistributionTypeId = userInvestment.DistributionTypeId;
                retVal.InvestedAmount = userInvestment.InvestedAmount;
                retVal.UniqueInvestmentId = userInvestment.InvestmentGUID;
                retVal.InvestmentTransactionLink = userInvestment.InvestmentTransactionLink;
                retVal.InvestmentTypeId = userInvestment.InvestmentTypeId;
                retVal.NetworkId = userInvestment.MonitoringType.Id;
                retVal.SaftFile = userInvestment.SaftFile;
                retVal.VestingId = userInvestment.VestingId;
                retVal.VestingLockup = userInvestment.VestingLockup;
                retVal.VestingTokenPercentage = userInvestment.VestingTokenPercentage;
                retVal.WebsiteLink = userInvestment.WebsiteLink;
                retVal.TokenId = userInvestment.TokenId;
                retVal.NumberOfToken = userInvestment.NumberOfToken;
            }
            retVal.AvailableDistributionTypes = GetSelectedListForEnum<DistributionTypes>();
            retVal.AvailableInvestmentTypes = GetSelectedListForEnum<InvestmentTypes>();
            retVal.AvailableNetworks = (await _portfolioMonitoringService.GetAllMonitoringTypesAsync()).Select(x => new SelectListItem()
            {
                Text = x.Type,
                Value = x.Id.ToString()
            }).ToList();
            retVal.AvailableContact = (await _contactService.GetUserContactsAsync(userId)).Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
            
            retVal.AvailableToken = (await _tokenService.GetAllByInvestmentId(investmentId)).Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();

            return retVal;
        }

        public async Task<InvestmentListModel> PrepareInvestmentListModelAsync(InvestmentSearchModel searchModel, int userId)
        {
            var userInvestments = await _investmentService.GetInvestmentListByUserIdAsync(userId, searchModel.Page - 1, searchModel.PageSize);
            //prepare list model
            return new InvestmentListModel().PrepareToGrid(searchModel, userInvestments, () =>
            {
                return userInvestments.Select(investment =>
                {
                    return new InvestmentModel()
                    {
                        AmountInvested = investment.InvestedAmount,
                        CoinAbbreviation = investment.MonitoringType.Abbreviation,
                        CoinImage = investment.MonitoringType.Icon,
                        CoinName = investment.MonitoringType.Type,
                        InvestedOnDateTime = investment.CreatedOnDateTimeUTC,
                        Id = investment.Id,
                        TransactionFee = 0.0005m,
                        WebsiteLink = investment.WebsiteLink
                    };
                });
            });            
        }
        #endregion

        #region Utilities     
        public static List<SelectListItem> GetSelectedListForEnum<T>() where T : System.Enum
        {
            var result = new Dictionary<int, string>();
            var values = Enum.GetValues(typeof(T));

            foreach (int item in values)
                result.Add(item, Enum.GetName(typeof(T), item));
            return result.Select(x => new SelectListItem
            {
                Value = x.Key.ToString(),
                Text = x.Value
            }).ToList();
        }

        public async Task<UserInvestmentModel> GetByIdAndUserId(int Id, int userId)
        {
            var userInvestment = await _investmentService.GetByIdAndUserId(userId, Id);
            var userInvestmentModel = new UserInvestmentModel();
            userInvestmentModel.UserId = userId;
            if (userInvestment != null)
            {
                userInvestmentModel.Id = userInvestment.Id;
                userInvestmentModel.DistributionTypeId = userInvestment.DistributionTypeId;
                userInvestmentModel.InvestedAmount = userInvestment.InvestedAmount;
                userInvestmentModel.UniqueInvestmentId = userInvestment.InvestmentGUID;
                userInvestmentModel.InvestmentTransactionLink = userInvestment.InvestmentTransactionLink;
                userInvestmentModel.InvestmentTypeId = userInvestment.InvestmentTypeId;
                userInvestmentModel.NetworkId = userInvestment.MonitoringTypeId;
                userInvestmentModel.SaftFile = userInvestment.SaftFile;
                userInvestmentModel.SaftPathSavedFileName = userInvestment.SaftPathSavedFileName;
                userInvestmentModel.VestingId = userInvestment.VestingId;
                userInvestmentModel.VestingLockup = userInvestment.VestingLockup;
                userInvestmentModel.VestingTokenPercentage = userInvestment.VestingTokenPercentage;
                userInvestmentModel.WebsiteLink = userInvestment.WebsiteLink;
                userInvestmentModel.Sign = userInvestment.Sign;
                userInvestmentModel.CustomLink = userInvestment.CustomLink;
                userInvestmentModel.DistributionPortal = userInvestment.DistributionPortal;
                userInvestmentModel.RefundAmount = userInvestment.RefundAmount;
                userInvestmentModel.ContactId = userInvestment.ContactId;
                userInvestmentModel.SignManually = userInvestment.Sign == null ? false : true;
                userInvestmentModel.InvestmentQuantity = userInvestment.InvestedQuantity;
                userInvestmentModel.TokenId = userInvestment.TokenId;
                userInvestmentModel.NumberOfToken = userInvestment.NumberOfToken;
            }
            userInvestmentModel.AvailableDistributionTypes = GetSelectedListForEnum<DistributionTypes>();
            userInvestmentModel.AvailableInvestmentTypes = GetSelectedListForEnum<InvestmentTypes>();
            userInvestmentModel.AvailableNetworks = (await _portfolioMonitoringService.GetAllMonitoringTypesAsync()).Select(x => new SelectListItem()
            {
                Text = x.Type,
                Value = x.Id.ToString()
            }).ToList();
            userInvestmentModel.DistributionType = userInvestment.DynamicDistributions.Select(x => new DistributionTypeModel
            {
                Lockup = x.Lookup,
                Peroid = Convert.ToInt32(x.Peroid),
                TGE = Convert.ToInt32(x.TGE),
                TokenPercentage = Convert.ToInt32(x.TokenPercentage)
            }).ToList();
            userInvestmentModel.SharedInvestmentPersonDetail = userInvestment.sharedInvestmentDetails.Select(x => new InvestmentSharedDetailViewModel
            {
                ContactId = x.ContactId,
                ContactName = x.Contact.Name,
                SharedPercentage = x.Percentage
            }).ToList();
            userInvestmentModel.AvailableContact = (await _contactService.GetUserContactsAsync(userId)).Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
            userInvestmentModel.AvailableToken = (await _tokenService.GetAll()).Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
            return userInvestmentModel;
        }       
        #endregion
    }
}
