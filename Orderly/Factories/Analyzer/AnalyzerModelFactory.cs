using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Orderly.Models.Analyzer;
using Orderly.Models.Comman;
using Orderly.Models.Distributor;
using Orderly.Models.Enums;
using Orderly.Models.Extensions;
using Orderly.Models.Portfolio;
using Orderly.Services.Comman;
using Orderly.Services.Contact;
using Orderly.Services.Investment;
using Orderly.Services.Portfolio;
using Orderly.Services.Token;
using Orderly.Services.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Orderly.Helpers.Common;

namespace Orderly.Factories.Analyzer
{
    public class AnalyzerModelFactory : IAnalyzerModelFactory
    {
        #region Properties
        private readonly IInvestmentService _investmentService;
        private readonly IApplicationUser _appUser;
        private readonly ServiceResolver<IPortfolioService> _serviceResolver;
        private readonly ICommanService _commanService;
        private readonly IPortfolioMonitoringService _portfolioMonitoringService;
        private readonly INetworkTokenService _networkTokenService;
        private readonly IContactService _contactService;
        private readonly IConfiguration _configuration;
        private static Dictionary<int, decimal> networkPrice;
        #endregion

        #region Constructor
        public AnalyzerModelFactory(IInvestmentService investmentService,
            IApplicationUser appUser,
            ServiceResolver<IPortfolioService> serviceResolver,
            ICommanService commanService,
            IPortfolioMonitoringService portfolioMonitoringService,
            INetworkTokenService networkTokenService,
            IContactService contactService,
            IConfiguration configuration)
        {
            _investmentService = investmentService;
            _appUser = appUser;
            _serviceResolver = serviceResolver;
            _commanService = commanService;
            _portfolioMonitoringService = portfolioMonitoringService;
            _networkTokenService = networkTokenService;
            _contactService = contactService;
            _configuration = configuration;
        }

        #endregion

        #region Methods
        public async Task<InvestmentAnalyzerListModel> PrepareInvestmentAnalyzerListModelAsync(InvestmentAnalyzerSearchModel searchModel)
        {
            var currentUser = await _appUser.GetCurrentUserAsync();
            var investments = await _investmentService.GetInvestmentListByUserIdAsync(currentUser.Id, searchModel.Page - 1, searchModel.PageSize, searchModel.FilterType, searchModel.FilterValue, searchModel.Keyword);
            networkPrice = new Dictionary<int, decimal>();
            //prepare list model
            var investmentList = new InvestmentAnalyzerListModel().PrepareToGrid(searchModel, investments, () =>
            {
                return investments.Select(x =>
                {
                    return new InvestmentAnalyzerModel()
                    {
                        Id = x.Id,
                        CreatedOnDateTimeUTC = x.CreatedOnDateTimeUTC,
                        DistributionTypeId = x.DistributionTypeId,
                        InvestedAmount = x.InvestedAmount,
                        InvestmentTypeId = x.InvestmentTypeId,
                        MonitoringTypeId = x.MonitoringTypeId,
                        Sign = x.Sign,
                        UpdatedOnDateTimeUTC = x.UpdatedOnDateTimeUTC,
                        VestingId = x.VestingId,
                        VestingLockup = x.VestingLockup,
                        VestingTokenPercentage = x.VestingTokenPercentage,
                        InvestedNetworkIcon = x.MonitoringType.Icon,
                        InvestedQuantity = Math.Round(Convert.ToDecimal(x.InvestedQuantity), 4), //static for now
                        InvestementAbbrivation = x.MonitoringType.Abbreviation,
                        ProfitOrLossPercentage = 20, //static for now
                        InvestmentTransactionLink = x.InvestmentTransactionLink,
                        CurrentAmountOfInvestedAmount = CurrentPriceOfInvestedAmt(x.InvestedQuantity, x.MonitoringTypeId).Result
                    };
                });
            });
            networkPrice = new Dictionary<int, decimal>();
            return investmentList;
        }

        private async Task<Decimal> CurrentPriceOfInvestedAmt(string investedQty, int networkId)
        {
            decimal currentAmount = 0;
            if (networkPrice.ContainsKey(networkId))
            {
                var currentRate = networkPrice[networkId];
                currentAmount = Math.Round(currentRate * Convert.ToDecimal(investedQty), 2);
            }
            else
            {
                var currentPrice = await getCurrencyPrice(networkId);
                networkPrice.Add(networkId, currentPrice);
                currentAmount = Math.Round(currentPrice * Convert.ToDecimal(investedQty), 2);
            }
            return currentAmount;
        }

        private async Task<decimal> getCurrencyPrice(int networkId)
        {
            decimal price = 0;
            var portfolioService = _serviceResolver(networkId.ToString());
            var getCurrencyRateResult = await portfolioService.GetCurrencyRate(GetApiKey(networkId));
            var currencyRate = JsonConvert.DeserializeObject<CurrencyModel>(getCurrencyRateResult);
            if (currencyRate.result != null)
            {
                price = Convert.ToDecimal(currencyRate.result.ethusd);
            }
            return price;
        }

        private string GetApiKey(int type)
        {
            var apiConfigSection = _configuration.GetSection("APIKeys");
            var apiKey = string.Empty;
            switch (type)
            {
                case (int)PortfolioMonitoringTypes.Etherum:
                    apiKey = Convert.ToString(apiConfigSection["apikeyETH"]);
                    break;
                case (int)PortfolioMonitoringTypes.BitCoin:
                    apiKey = Convert.ToString(apiConfigSection["apikeyBTC"]);
                    break;
            }
            return apiKey;
        }

        public async Task<DistributionTansactionsListModel> PrepareInvestmentDistributionListModelAsync(DistributionTransactionSearchModel searchModel)
        {
            var portfolioService = _serviceResolver(searchModel.NetworkId.ToString());
            var network = (await _portfolioMonitoringService.GetAllMonitoringTypesAsync(searchModel.NetworkId)).FirstOrDefault();
            var result = await portfolioService.GetTransactionlistByTransactionLink(searchModel.TransactionLink, _commanService.GetApiByKey(searchModel.NetworkId));
            if (result != null)
            {
                var response = JsonConvert.DeserializeObject<TansactionResponseModel>(result);
                if (response.status == RequestStatus.OK)
                {
                    var transactions = await response.result.AsQueryable().ToPagedListAsync(searchModel.Page - 1, searchModel.PageSize);
                    return new DistributionTansactionsListModel().PrepareToGrid(searchModel, transactions, () =>
                    {
                        return transactions.Select(x =>
                        {
                            System.DateTime datetime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                            return new DistributionTansactionsModel()
                            {
                                TransactionHexCode = searchModel.TransactionLink,
                                Date = datetime.AddSeconds(double.Parse(x.timeStamp)),
                                From = x.from,
                                To = x.to,
                                NetworkAbbrivation = network.Abbreviation,
                                Quantity = (Convert.ToDecimal(x.value) / 1000000000000000000),
                                Value = 0//static for now
                            };
                        });
                    });
                }
            }
            return new DistributionTansactionsListModel();
        }

        public async Task<List<SelectListItem>> GetFiltersData(int filterType)
        {
            List<SelectListItem> options = new List<SelectListItem>();
            var userId = (await _appUser.GetCurrentUserAsync()).Id;
            if (filterType == Convert.ToInt32(AnalyzerFilter.Address))
            {
                var address = await _contactService.GetByUserId(userId);
                options = address.Select(x => new SelectListItem
                {
                    Text = x.Address + " (" + x.Name + ")",
                    Value = x.Id.ToString()
                }).ToList();
            }
            else if (filterType == Convert.ToInt32(AnalyzerFilter.Network))
            {
                var network = await _portfolioMonitoringService.GetAllMonitoringTypesAsync();
                options = network.Select(x => new SelectListItem
                {
                    Text = !string.IsNullOrEmpty(x.Abbreviation) ? x.Type + " (" + x.Abbreviation + ")" : x.Type,
                    Value = x.Id.ToString()
                }).ToList();
            }
            else
            {
                var token = await _networkTokenService.GetAll();
                options = token.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }).ToList();
            }
            return options;
        }

        public async Task<Dictionary<string, decimal>> PrepareGraphDataAsync(string dateRange)
        {
            var dataDictionary = new Dictionary<string, decimal>();
            var currentUser = await _appUser.GetCurrentUserAsync();
            var investments = await _investmentService.GetInvestmentsByUserIdAsync(currentUser.Id);
            var totalInvested = investments.GroupBy(x => x.MonitoringTypeId).Select(x => new {
                typeId = x.Key,
                amount = x.Sum(x => x.InvestedAmount)
            }).ToList().Distinct();
            
            DateTime startDate = DateTime.UtcNow;
            DateTime endDate = DateTime.UtcNow;
            switch (dateRange.ToLower())
            {
                case "1d":
                    startDate = DateTime.UtcNow.AddDays(-1);                    
                    break; 
                case "5d":
                    startDate = DateTime.UtcNow.AddDays(-5);                    
                    break;
                case "1m":
                    startDate = DateTime.UtcNow.AddMonths(-1);                    
                    break;
                case "1y":
                    startDate = DateTime.UtcNow.AddYears(-1);                    
                    break; 
                case "5y":
                    startDate = DateTime.UtcNow.AddYears(-5);                    
                    break;
            }

            var graphData = new Dictionary<string, decimal>();
            foreach (var invested in totalInvested)
            {
                var portfolioService = _serviceResolver(Convert.ToInt32(invested.typeId).ToString());
                var response = await portfolioService.GetDailyCurrency(_commanService.GetApiByKey(Convert.ToInt32(invested.typeId), true), startDate, endDate);
                var result = JsonConvert.DeserializeObject<DailyPriceResponseModel>(response);
                if(result != null)
                {
                    graphData = new Dictionary<string, decimal>();
                    foreach (var price in result.result)
                    {
                        graphData.Add(price.UTCDate, Math.Round((Convert.ToDecimal(price.value) * invested.amount), 2));
                    }
                }
            }
            if(graphData.Count > 0)
            {
                dataDictionary = graphData.GroupBy(x => x.Key)
                    .ToDictionary(x => x.Key, x => x.Sum(y => y.Value));
            }
            return dataDictionary;
        }
        #endregion


    }
}
