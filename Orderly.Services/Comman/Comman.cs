using Microsoft.Extensions.Configuration;

using Newtonsoft.Json.Linq;

using Orderly.Models.Enums;
using Orderly.Services.Portfolio;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Orderly.Helpers.Common;

namespace Orderly.Services.Comman
{

    public class CommanService : ICommanService
    {
        #region Properties
        private readonly IConfiguration _configuration;
        private readonly ServiceResolver<IPortfolioService> _serviceResolver;
        #endregion
        public CommanService(IConfiguration configuration,
            ServiceResolver<IPortfolioService> serviceResolver)
        {
            _configuration = configuration;
            _serviceResolver = serviceResolver;
        }
        public string GetApiByKey(int networkId, bool proAPI = false)
        {
            var apiConfigSection = _configuration.GetSection("APIKeys");
            var apiKey = string.Empty;
            switch (networkId)
            {
                case (int)PortfolioMonitoringTypes.Etherum:
                    if (!proAPI)
                        apiKey = Convert.ToString(apiConfigSection["apikeyETH"]);
                    else
                        apiKey = Convert.ToString(apiConfigSection["apikeyProETH"]);
                    break;
                case (int)PortfolioMonitoringTypes.BitCoin:
                    if (!proAPI)
                        apiKey = Convert.ToString(apiConfigSection["apikeyBTC"]);
                    else
                        apiKey = Convert.ToString(apiConfigSection["apikeyProBTC"]);
                    break;
                case (int)ApiKeyType.EthPlorer:
                    apiKey = Convert.ToString(apiConfigSection["apiKeyEthPlorer"]);
                    break;
                case (int)ApiKeyType.CryptoCompare:
                    apiKey = Convert.ToString(apiConfigSection["apiKeyCryptoCompare"]);
                    break;
            }
            return apiKey;
        }

        public string getArrowHtmlbyDirection(int direction)
        {
            StringBuilder arrowHtml = new StringBuilder();
            switch (direction)
            {
                case (int)Direction.Up:
                    arrowHtml.Append("<svg width=\"16\" height =\"16\" viewBox =\"0 0 16 16\" fill=\"none\" xmlns =\"http://www.w3.org/2000/svg \">");
                    arrowHtml.Append("<path d=\"M8 6V11.4\" stroke=\"#689F38\" stroke-width=\"1.4\" stroke-linecap=\"round\"/>");
                    arrowHtml.Append("<path d=\"M6 7L8 5L10 7\" stroke=\"#689F38\" stroke-width=\"1.4\" stroke-linecap=\"round\"/>");
                    arrowHtml.Append("</svg>");
                    break;
                case (int)Direction.Down:
                    arrowHtml.Append("<svg width=\"6\" height=\"9\" viewBox=\"0 0 6 9\" fill=\"none\" xmlns=\"http://www.w3.org/2000/svg \">");
                    arrowHtml.Append("<path d = \"M3 6.39999V0.999994\" stroke = \"#E74C3C\" stroke-width = \"1.4\" stroke-linecap = \"round\" />");
                    arrowHtml.Append("<path d = \"M1 5.39999L3 7.39999L5 5.39999\" stroke = \"#E74C3C\" stroke-width = \"1.4\" stroke-linecap = \"round\" />");
                    arrowHtml.Append("</svg>");
                    break;
                default:
                    break;
            }
            return arrowHtml.ToString();
        }

        public async Task<Tuple<decimal, decimal>> GetCurrentAndLast24HrsPrice(string networkSymbol, int networkId)
        {
            decimal last24HrsPrice = 0;
            decimal currentPrice = 0;
            var portfolioService = _serviceResolver(networkId.ToString());
            var cryptoCompareApiKey = GetApiByKey(Convert.ToInt32(ApiKeyType.CryptoCompare));

            var last24HrsPriceResult = await portfolioService.GetTokenHistory(cryptoCompareApiKey, networkSymbol, Currency.USD.ToString());
            if (!string.IsNullOrEmpty(last24HrsPriceResult))
            {
                dynamic data = JObject.Parse(last24HrsPriceResult);
                if (!Object.ReferenceEquals(null, data))
                {
                    var rawData = data.RAW;
                    if (!Object.ReferenceEquals(null, rawData))
                    {
                        var symbol = networkSymbol.ToUpper();
                        var symbolData = rawData[symbol];
                        if (!Object.ReferenceEquals(null, symbolData))
                        {
                            var currencyData = symbolData[Currency.USD.ToString()];
                            if (!Object.ReferenceEquals(null, currencyData))
                            {
                                currentPrice = Convert.ToDecimal(currencyData.PRICE);
                                var change24Hrs = Convert.ToDecimal(currencyData.CHANGE24HOUR);
                                last24HrsPrice = currentPrice - change24Hrs;
                            }
                        }
                    }
                }
            }
            return new Tuple<decimal, decimal>(currentPrice, last24HrsPrice);
        }


        public void ProcessAllQueuedEmails(bool tryFailed = false)
        {
            throw new NotImplementedException();
        }
    }
}
