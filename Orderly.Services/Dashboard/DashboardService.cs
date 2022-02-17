using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using Orderly.Core.Domain.Investment;
using Orderly.Core.Domain.Portfolio;
using Orderly.Core.Domain.Tokens;
using Orderly.Models.Dashboard;
using Orderly.Models.Enums;
using Orderly.Models.ViewModels;
using Orderly.Repositories;
using Orderly.Services.Comman;
using Orderly.Services.Portfolio;
using Orderly.Services.Token;
using Orderly.Services.User;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using static Orderly.Helpers.Common;

namespace Orderly.Services.Dashboard
{
    public class DashboardService : IDashboardService
    {
        #region Properties
        private readonly IRepository<PortfolioMonitoring> _portFolioMonitoringRepository;
        private readonly IRepository<MonitoringType> _monitoringtypeRepository;
        private readonly ICommanService _commanService;
        private readonly ServiceResolver<IPortfolioService> _serviceResolver;
        private readonly INetworkTokenService _networkTokenService;
        private readonly IRepository<Calendar> _calendarRepository;
        #endregion
        #region Constructor
        public DashboardService(IRepository<PortfolioMonitoring> portFolioMonitoringRepository,
            IRepository<MonitoringType> monitoringtypeRepository,
            ICommanService commanService,
            ServiceResolver<IPortfolioService> serviceResolver,
            INetworkTokenService networkTokenService,
            IRepository<Calendar> calendarRepository
            )
        {
            _portFolioMonitoringRepository = portFolioMonitoringRepository;
            _monitoringtypeRepository = monitoringtypeRepository;
            _commanService = commanService;
            _serviceResolver = serviceResolver;
            _networkTokenService = networkTokenService;
            _calendarRepository = calendarRepository;
        }
        #endregion

        #region Method
        public async Task<DashboardModel> BindData(int userId, List<int> networkIds)
        {
            DashboardModel dashboardModel = new DashboardModel();
            dashboardModel.TokenSearchModel = new TokenSearchModel();
            dashboardModel.TokenSearchModel.NextDays = 30;
            dashboardModel.TokenSearchModel.PrevDays = 30;
            var liquidAmount = await GetLiquidAmount(userId, networkIds);
            dashboardModel.LiquidValue = liquidAmount.Item1;
            var Last24HrsLiquidValue = liquidAmount.Item2;
            await SetLiquidAthAndAtlPrice(dashboardModel, userId, networkIds);
            await GetLockedAmount(dashboardModel, userId, networkIds);

            var assetsBalance = Convert.ToDecimal(dashboardModel.LockedValue) + Convert.ToDecimal(dashboardModel.LiquidValue);
            var last24HrsAssetsAmount = dashboardModel.Last24HrsLockedValue + Convert.ToDecimal(Last24HrsLiquidValue);
            var last24HrsDiff = Math.Round((assetsBalance - last24HrsAssetsAmount), 2);
            string arrowHtml = string.Empty;
            if (last24HrsDiff > 0)
            {
                dashboardModel.LastTwentyHoursDifference = "+ $" + Convert.ToString(last24HrsDiff) + " (24h)";
                arrowHtml = _commanService.getArrowHtmlbyDirection((int)Direction.Up);

            }
            else if (last24HrsDiff == 0)
            {
                dashboardModel.LastTwentyHoursDifference = "$" + Convert.ToString(last24HrsDiff) + " (24h)";
            }
            else
            {
                dashboardModel.LastTwentyHoursDifference = "- $" + Convert.ToString((-1) * last24HrsDiff) + " (24h)";
                arrowHtml = _commanService.getArrowHtmlbyDirection((int)Direction.Down);
            }
            dashboardModel.AssetBalance = Math.Round(assetsBalance,2);

            if (assetsBalance > 0)
            {
                decimal diffAmount = last24HrsDiff;
                var spanHtml = "<span class = \"text-success\">";
                if (last24HrsDiff < 0)
                {
                    spanHtml = "<span class = \"text-danger\">";
                    diffAmount = (-1)*(last24HrsDiff);
                }
                var upDownPercentage = Math.Round(((diffAmount / assetsBalance)* 100), 2);
                dashboardModel.UpDownPercentage = arrowHtml + spanHtml + Convert.ToString(upDownPercentage) + "%</span>";
            }
            else
            {
                dashboardModel.UpDownPercentage = "0.00%";
            }
            return dashboardModel;
        }

        private async Task<Tuple<decimal, decimal>> GetLiquidAmount
            (int userId, List<int> networkIds)
        {
            decimal sumOfTokenValue = 0;
            decimal sumOfLast24hrsTokenValue = 0;
            try
            {
                var apiKey = _commanService.GetApiByKey(Convert.ToInt32(ApiKeyType.EthPlorer));
                var portFolioMonitoring = (await _portFolioMonitoringRepository.GetAllAsync()).Include(x => x.User).Include(x => x.MonitoringType);
                var addresses = portFolioMonitoring.Where(x => x.User.Id == userId && networkIds.Contains(x.MonitoringType.Id)).OrderBy(x => x.MonitoringType.Id).ToList();
                int prevAddressId = 0;
                IPortfolioService portfolioService = null;
                foreach (var address in addresses)
                {
                    if (prevAddressId == 0)
                    {
                        prevAddressId = address.MonitoringType.Id;
                        portfolioService = _serviceResolver(address.MonitoringType.Id.ToString());
                    }
                    else
                    {
                        if (prevAddressId != address.MonitoringType.Id)
                        {
                            portfolioService = _serviceResolver(address.MonitoringType.Id.ToString());
                        }
                    }
                    var addressDetails = "";
                    try
                    {
                        addressDetails = await portfolioService.GetAllTokenByAddress(apiKey, address.Address);
                    }
                    catch (Exception ex)
                    {
                        var msg = ex.Message;
                    }
                    if (!string.IsNullOrEmpty(addressDetails))
                    {
                        var result = JsonConvert.DeserializeObject<AddressDetailsResponse>(addressDetails);
                        if (result != null)
                        {
                            if (result.tokens != null)
                            {
                                foreach (var token in result.tokens)
                                {
                                    var balance = Convert.ToDouble(token.rawBalance);
                                    if (balance > 0)
                                    {
                                        var tokenInfo = token.tokenInfo;

                                        if (tokenInfo != null)
                                        {
                                            var decimalValue = Convert.ToInt32(tokenInfo.decimals);
                                            decimal tokenValue = 0;
                                            if (decimalValue > 0)
                                            {
                                                tokenValue = Convert.ToDecimal(balance / Math.Pow(10, decimalValue));
                                            }
                                            else
                                            {
                                                tokenValue = Convert.ToDecimal(balance);
                                            }

                                            Tuple<decimal, decimal> prices = new Tuple<decimal,decimal>(0,0);
                                            if (!string.IsNullOrEmpty(tokenInfo.symbol))
                                            {
                                                prices = await _commanService.GetCurrentAndLast24HrsPrice(tokenInfo.symbol, Convert.ToInt32(ApiKeyType.Etherum));
                                            }

                                            var currentPrice = prices.Item1;
                                            var tokenAmount = tokenValue * currentPrice;
                                            sumOfTokenValue += tokenAmount;

                                            /// get last 24 hours changed price
                                            try
                                            {
                                                decimal last24HrsPrice = prices.Item2;
                                                sumOfLast24hrsTokenValue += last24HrsPrice * tokenValue;
                                            }
                                            catch (Exception ex)
                                            {
                                                var msg = ex.Message;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
            return new Tuple<decimal, decimal>(Math.Round(sumOfTokenValue, 2), Math.Round(sumOfLast24hrsTokenValue, 2));
        }

        private async Task<DashboardModel> SetLiquidAthAndAtlPrice(DashboardModel dashboardModel, int userId, List<int> networkIds)
        {
            var token = await _networkTokenService.GetWalletToken(networkIds, userId);
            if (token != null)
            {
                dashboardModel.LiquidATH = token.Sum(x => x.AllTimeHighValue);
                dashboardModel.LiquidATL = token.Sum(x => x.AllTimeLowValue);
            }
            return dashboardModel;
        }

        private async Task<DashboardModel> GetLockedAmount(DashboardModel dashboardModel, int userId, List<int> networkIds)
        {
            decimal lockedValue = 0;
            decimal lockedATHValue = 0;
            decimal lockedATLValue = 0;
            decimal last24HrsLockedValue = 0;

            var tokens = await (await _calendarRepository.GetAllAsync(x => x.Date.Date <= DateTime.Now.Date && x.Token.UserId == userId && networkIds.Contains(x.Token.NetworkId)))
                .GroupBy(x => x.TokenId).Select(x => new { tokenId = x.Key, count = x.Count() }).ToListAsync();

            foreach (var token in tokens)
            {
                try
                {
                    var networkToken = await _networkTokenService.GetById(token.tokenId);
                    Tuple<decimal, decimal> prices = new Tuple<decimal, decimal>(0, 0);
                    if (!string.IsNullOrEmpty(networkToken.Symbol))
                    {
                        prices = await _commanService.GetCurrentAndLast24HrsPrice(networkToken.Symbol, networkToken.NetworkId);
                    }
                    var currentPrice = prices.Item1;
                    decimal last24HrsPrice = prices.Item2;
                    last24HrsLockedValue += Math.Round(last24HrsPrice * token.count, 2);

                    decimal tokenPrice = Convert.ToDecimal(currentPrice);
                    decimal HighValue = Convert.ToDecimal(networkToken.AllTimeHighValue);
                    decimal LowValue = Convert.ToDecimal(networkToken.AllTimeLowValue);
                    var lockValue = tokenPrice * token.count;
                    var lockATH = HighValue * token.count;
                    var lockATL = LowValue * token.count;
                    lockedValue += lockValue;
                    lockedATHValue += lockATH;
                    lockedATLValue += lockATL;
                }
                catch (Exception ex)
                {
                }
            }
            dashboardModel.LockedATH = Math.Round(lockedATHValue, 2);
            dashboardModel.LockedATL = Math.Round(lockedATLValue, 2);
            dashboardModel.LockedValue = Math.Round(lockedValue,2);
            dashboardModel.Last24HrsLockedValue = last24HrsLockedValue;
            return dashboardModel;
        }
        #endregion
    }
}
