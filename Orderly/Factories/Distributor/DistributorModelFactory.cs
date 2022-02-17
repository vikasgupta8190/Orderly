using Newtonsoft.Json;

using Orderly.Models.Comman;
using Orderly.Models.Distributor;
using Orderly.Models.Extensions;
using Orderly.Models.Portfolio;
using Orderly.Services.Comman;
using Orderly.Services.Investment;
using Orderly.Services.Portfolio;
using Orderly.Services.Token;
using Orderly.Services.User;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using static Orderly.Helpers.Common;

namespace Orderly.Factories.Distributor
{
    public class DistributorModelFactory : IDistributorModelFactory
    {
        #region Properties
        private readonly IPortfolioMonitoringService _portfolioMonitoringService;
        private readonly IApplicationUser _applicationUser;
        private readonly ServiceResolver<IPortfolioService> _serviceResolver;
        private readonly ICommanService _commanService;
        private readonly INetworkTokenService _networkTokenService;
        private readonly IInvestmentService _investmentService;
        #endregion
        #region Constructor
        public DistributorModelFactory(IPortfolioMonitoringService portfolioMonitoringService,
            IApplicationUser applicationUser,
            ServiceResolver<IPortfolioService> serviceResolver,
            ICommanService commanService,
            INetworkTokenService networkTokenService,
            IInvestmentService investmentService)
        {
            _portfolioMonitoringService = portfolioMonitoringService;
            _applicationUser = applicationUser;
            _serviceResolver = serviceResolver;
            _commanService = commanService;
            _networkTokenService = networkTokenService;
            _investmentService = investmentService;
        }
        #endregion

        public async Task<TransactionDetailModelList> PrepareTransactionDetailListModelAsync(TransactionDetailSearchModel searchModel)
        {
            var currentUser = await _applicationUser.GetCurrentUserAsync();
            var userPortfolios = await _portfolioMonitoringService.GetAllAddressesByUserIdAsync(currentUser.Id);
            var investments = await _investmentService.GetInvestmentsByUserIdAsync(currentUser.Id);

            var pricing = new Dictionary<int, CurrencyModel>();
            if (!string.IsNullOrEmpty(searchModel.Address))
                userPortfolios = userPortfolios.Where(x => x.Address == searchModel.Address).ToList();
            //  userPortfolios = userPortfolios.Where(x => x.MonitoringType.Id == searchModel.TokensType).ToList();
            var list = new List<string>();
            var allTokens = new List<TransactionsResult>();
            decimal investedAmount;
            System.DateTime datetime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            var tokens = await _networkTokenService.GetAll();
            if (searchModel.TokensType > 0)
                tokens = tokens.Where(x => x.Id == searchModel.TokensType).ToList();
            foreach (var portfolio in userPortfolios)
            {
                if (!list.Any(x => x == portfolio.Address))
                {
                    list.Add(portfolio.Address);
                    foreach (var token in tokens.Where(x => x.NetworkId == portfolio.MonitoringType.Id))
                    {
                        var portfolioService = _serviceResolver(portfolio.MonitoringType.Id.ToString());
                        var result = await portfolioService.GetTransactionDetailByContractIdAndAddress(token.Address, portfolio.Address, _commanService.GetApiByKey(portfolio.MonitoringType.Id));//, searchModel.Page, searchModel.PageSize);
                        var response = JsonConvert.DeserializeObject<TansactionResponseModel>(result);
                        if (response.result.Count > 0)
                        {
                            response.result.ForEach(x => x.userAddress = portfolio.Address); //set address values
                            response.result.ForEach(x => x.networkId = portfolio.MonitoringType.Id); //set networkId

                            if (searchModel.AnyPeriod.HasValue)
                                response.result = response.result.Where(x => datetime.AddSeconds(double.Parse(x.timeStamp)) >= searchModel.AnyPeriod.Value).ToList();
                            allTokens.AddRange(response.result);
                        }
                        if (!pricing.Any(x => x.Key == portfolio.MonitoringType.Id))
                        {
                            var pricingResult = await portfolioService.GetCurrencyRate(_commanService.GetApiByKey(portfolio.MonitoringType.Id));
                            pricing.Add(portfolio.MonitoringType.Id, JsonConvert.DeserializeObject<CurrencyModel>(pricingResult));
                        }
                    }
                }
            }

            allTokens = allTokens.OrderByDescending(x => datetime.AddSeconds(double.Parse(x.timeStamp))).ToList();
            //filtering data on the basis of tabs
            searchModel.FilterType = searchModel.FilterType == null ? "All" : searchModel.FilterType;
            if (searchModel.FilterType.ToLower() == "out")
                allTokens = allTokens.Where(x => x.from == x.userAddress).ToList();
            else if (searchModel.FilterType.ToLower() == "in")
                allTokens = allTokens.Where(x => x.to == x.userAddress).ToList();

            var pagedListTokens = await allTokens.AsQueryable().ToPagedListAsync(searchModel.Page - 1, searchModel.PageSize);
            var model = new TransactionDetailModelList().PrepareToGrid(searchModel, pagedListTokens, () =>
             {
                 return pagedListTokens.Select(token =>
                 {
                     //System.DateTime datetime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                     datetime = datetime.AddSeconds(double.Parse(token.timeStamp));


                     //var intValue = Convert.ToInt64(token.value, 16);
                     var etherValue = (Convert.ToDecimal(token.value) / 1000000000000000000);
                     /// get current currency rate
                     var currencyRate = pricing.Where(x => x.Key == token.networkId).Select(x => x.Value).FirstOrDefault();
                     investedAmount = 0;
                     if (currencyRate != null)
                     {
                         var etherumValue = Convert.ToDecimal(currencyRate.result.ethusd);
                         investedAmount = Math.Round(etherumValue * etherValue, 2);
                     }

                     var model = new Orderly.Models.Distributor.TransactionDetailModel()
                     {
                         Date = datetime,
                         From = token.from,
                         Quantity = decimal.Parse(token.value) / 1000000000000000000,
                         QuantityPostfix = "UNI",
                         TansactionHashCode = token.blockHash,
                         To = token.to,
                         UserAddress = token.userAddress,
                         DollarAmount = investedAmount
                     };
                     return model;
                 });
             });
            var values = allTokens.Where(x => x.from == x.userAddress).Select(x => new { value = Convert.ToDecimal(x.value), x.networkId });
            foreach (var token in values.Select(x => x.networkId).Distinct())
            {
                var tokenValue = values.Where(x => x.networkId == token).Select(x => x.value).Sum();
                var etherValue = (tokenValue / 1000000000000000000);
                /// get current currency rate
                var currencyRate = pricing.Where(x => x.Key == token).Select(x => x.Value).FirstOrDefault();
                decimal totalDistributed = 0;
                if (currencyRate != null)
                {
                    var etherumValue = Convert.ToDecimal(currencyRate.result.ethusd);
                    totalDistributed = Math.Round(etherumValue * etherValue, 2);
                }
                model.TotalDisributed += totalDistributed;
                foreach (var investment in investments.Where(x=>x.MonitoringTypeId== token))
                {
                    foreach (var share in investment.sharedInvestmentDetails)
                    {

                        var networkShares = (share.Percentage / 100) * (Convert.ToDecimal(investment.InvestedQuantity));
                        var etherumValue = Convert.ToDecimal(currencyRate.result.ethusd);
                        model.TotalToBeDisributed += Math.Round(etherumValue * networkShares, 2);
                    }
                }
                model.TotalToBeDisributed += model.TotalToBeDisributed - model.TotalDisributed;
            }
          
            return model;
        }
        public async Task<DistributorAddressesModel> PrepareAddressModelAsync(int userId)
        {
            DistributorAddressesModel distributorAddressesModel = new DistributorAddressesModel();
            distributorAddressesModel.Addresses = new List<Addresses>();
            return distributorAddressesModel;
        }
    }
}
