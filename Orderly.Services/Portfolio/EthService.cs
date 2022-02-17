using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Orderly.Services.Portfolio
{
    public class EthService : IPortfolioService
    {
        #region Properties
        private readonly string BaseUrl = "https://api.etherscan.io/api";
        private readonly string EthplorerUrl = "https://api.ethplorer.io/";
        private readonly string CryptoCompareUrl = "https://min-api.cryptocompare.com/data/";
        #endregion

        #region Methods
        public async Task<string> ValidateAddressAsync(string address, string apiKey)
        {
            return await GetResourceDataAsync(string.Format("{0}?module={1}&action={2}&address={3}&apikey={4}", BaseUrl, "account", "balance", address, apiKey));
        }

        public async Task<string> ValidateInvestmentTransactionLinkAsync(string transactionLink, string apiKey)
        {
            return await GetResourceDataAsync(string.Format("{0}?module={1}&action={2}&txhash={3}&apikey={4}", BaseUrl, "transaction", "gettxreceiptstatus", transactionLink, apiKey));
        }

        public async Task<string> GetCurrencyRate(string apiKey)
        {
            return await GetResourceDataAsync(string.Format("{0}?module={1}&action={2}&apikey={3}", BaseUrl, "stats", "ethprice", apiKey));
        }

        public async Task<string> ValidateContractAsync(string address, string apiKey)
        {
            return await GetResourceDataAsync(string.Format("{0}?module={1}&action={2}&address={3}&apikey={4}", BaseUrl, "contract", "getsourcecode", address, apiKey));
        }

        public async Task<string> GetDetailByTransactionLink(string transactionLink, string apiKey)
        {
            return await GetResourceDataAsync(string.Format("{0}?module={1}&action={2}&txhash={3}&apikey={4}", BaseUrl, "proxy", "eth_getTransactionByHash", transactionLink, apiKey));
        }

        public async Task<string> GetTransactionDetailByContractIdAndAddress(string contractId, string addressId, string apiKey, int page = 1, int pageOffset = 9999)
        {
            return await GetResourceDataAsync(string.Format("{0}?module={1}&action={2}&contractaddress={3}&address={4}&page={5}&offset={6}&startblock={7}&endblock={8}&sort={9}&apikey={10}", BaseUrl, "account", "tokentx", contractId, addressId, page, pageOffset, 0, 27025780, "asc", apiKey));
        }

        public async Task<string> GetTransactionListByUserAddress(string address, string apiKey, DateTime? startDate = null, DateTime? endDate = null)//, int pageNumber = 1, int pageSize = int.MaxValue)
        {
            //return await GetResourceDataAsync(string.Format("{0}?module={1}&action={2}&address={3}&apikey={4}&page={5}&offset={6}", BaseUrl, "account", "txlist", address, apiKey, pageNumber, pageSize));
            if (startDate.HasValue && endDate.HasValue)
                return await GetResourceDataAsync(string.Format("{0}?module={1}&action={2}&address={3}&apikey={4}&startdate={5}&enddate={6}", BaseUrl, "account", "txlist", address, apiKey, startDate.Value, endDate.Value));
            if (startDate.HasValue && !endDate.HasValue)
                return await GetResourceDataAsync(string.Format("{0}?module={1}&action={2}&address={3}&apikey={4}&startdate={5}&enddate={6}", BaseUrl, "account", "txlist", address, apiKey, startDate.Value, startDate.Value));
            return await GetResourceDataAsync(string.Format("{0}?module={1}&action={2}&address={3}&apikey={4}", BaseUrl, "account", "txlist", address, apiKey));
        }

        public async Task<string> GetTransactionlistByTransactionLink(string transctionLink, string apiKey, DateTime? startDate = null, DateTime? endDate = null)
        {
            return await GetResourceDataAsync(string.Format("{0}?module={1}&action={2}&txhash={3}&apikey={4}", BaseUrl, "account", "txlistinternal", transctionLink, apiKey));
        }

        public async Task<string> GetDailyCurrency(string apiKey, DateTime startDate, DateTime endDate)
        {
            if (!string.IsNullOrEmpty(apiKey))
            {
                return await GetResourceDataAsync(string.Format("{0}?module={1}&action={2}&startdate={3}&enddate={4}&sort={5}&apikey={6}", BaseUrl, "stats", "ethdailyprice", startDate.ToString("yyyy-MM-dd"), endDate.ToString("yyyy-MM-dd"), "asc", apiKey));
            }
            else
            {
                return string.Empty;
            }
        }

        public async Task<string> GetTokenInfo(string apiKey,string contractAddress)
        {
            return await GetResourceDataAsync(string.Format("{0}?module={1}&action={2}&contractaddress={3}&apikey={4}", BaseUrl, "token", "tokeninfo", contractAddress, apiKey));
        }

        public async Task<string> GetAllTokenByAddress(string apiKey, string address)
        {
            return await GetResourceDataAsync(string.Format("{0}{1}/{2}?apiKey={3}", EthplorerUrl, "getAddressInfo", address, apiKey));
        }

        /// <summary>
        /// get token information 
        /// reference from "https://github.com/EverexIO/Ethplorer/wiki/Ethplorer-API#get-token-info"
        /// </summary>
        /// <param name="apiKey"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        public async Task<string> GetTokenInformation(string apiKey, string address)
        {
            return await GetResourceDataAsync(string.Format("{0}{1}/{2}?apiKey={3}", EthplorerUrl, "getTokenInfo", address, apiKey));
        }

        public async Task<string> GetTokenHistory(string apiKey, string networkSymbol,string currencySymbol)
        {
            var test = string.Format("{0}{1}?fsyms={2}&tsyms={3}&api_key={4}", CryptoCompareUrl, "pricemultifull", networkSymbol, currencySymbol, apiKey);
            return await GetResourceDataAsync(string.Format("{0}{1}?fsyms={2}&tsyms={3}&api_key={4}", CryptoCompareUrl, "pricemultifull", networkSymbol, currencySymbol, apiKey));
        }

        #endregion

        #region Utitlities
        private async Task<string> GetResourceDataAsync(string url)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                return string.Empty;
            }
        }

        #endregion
    }
}
