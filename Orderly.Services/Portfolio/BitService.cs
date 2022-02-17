using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Orderly.Services.Portfolio
{
    public class BitService : IPortfolioService
    {
        #region Properties
        private readonly string BaseUrl = "https://api.bscscan.com/api";
        private readonly string CryptoCompareUrl = "https://min-api.cryptocompare.com/data/";
        private readonly string EthplorerUrl = "https://api.ethplorer.io/";
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
            return await GetResourceDataAsync(string.Format("{0}?module={1}&action={2}&apikey={3}", BaseUrl, "stats", "bnbprice", apiKey));
        }

        public async Task<string> ValidateContractAsync(string address, string apiKey)
        {
            return await GetResourceDataAsync(string.Format("{0}?module={1}&action={2}&address={3}&apikey={4}", BaseUrl, "contract", "getsourcecode", address, apiKey));
        }

        public async Task<string> GetDetailByTransactionLink(string transactionLink, string apiKey)
        {
            return await GetResourceDataAsync(string.Format("{0}?module={1}&action={2}&txhash={3}&apikey={4}", BaseUrl, "proxy", "eth_getTransactionByHash", transactionLink, apiKey));
        }

        public async Task<string> GetTransactionListByUserAddress(string address, string apiKey, DateTime? startDate = null, DateTime? endDate = null)//, int pageNumber = 1, int pageSize = int.MaxValue)
        {
            //return await GetResourceDataAsync(string.Format("{0}?module={1}&action={2}&address={3}&apikey={4}&page={5}&offset={6}", BaseUrl, "account", "txlist", address, apiKey, pageNumber, pageSize));
            return await GetResourceDataAsync(string.Format("{0}?module={1}&action={2}&address={3}&apikey={4}", BaseUrl, "account", "txlist", address, apiKey));
        }

        public async Task<string> GetTransactionDetailByContractIdAndAddress(string contractId, string addressId, string apiKey,int page=1,int pageOffset=9999)
        {
            return await GetResourceDataAsync(string.Format("{0}?module={1}&action={2}&contractaddress={3}&address={4}&page={5}&offset={6}&startblock={7}&endblock={8}&sort={9}&apikey={10}",BaseUrl,"account","tokentx",contractId,addressId,page,pageOffset,0, 27025780, "asc", apiKey));
        }

        public async Task<string> GetTransactionlistByTransactionLink(string transctionLink, string apiKey, DateTime? startDate = null, DateTime? endDate = null)
        {
            return await GetResourceDataAsync(string.Format("{0}?module={1}&action={2}&txhash={3}&apikey={4}", BaseUrl, "account", "txlistinternal", transctionLink, apiKey));
        }

        public async Task<string> GetDailyCurrency(string apiKey, DateTime startDate, DateTime endDate)
        {
            if (!string.IsNullOrEmpty(apiKey))
            {
                return await GetResourceDataAsync(string.Format("{0}?module={1}&action={2}&startdate={3}&enddate={4}&sort={5}&apikey={6}", BaseUrl, "stats", "bnbdailyprice", startDate.ToString("yyyy-MM-dd"), endDate.ToString("yyyy-MM-dd"), "asc", apiKey));
            }
            else
            {
                return string.Empty;
            }
        }

        public async Task<string> GetTokenInfo(string apiKey, string contractAddress)
        {
            return await GetResourceDataAsync(string.Format("{0}?module={1}&action={2}&contractaddress={3}&apikey={4}", BaseUrl, "token", "tokeninfo", contractAddress, apiKey));
        }
        public async Task<string> GetAllTokenByAddress(string apiKey, string address)
        {
            return await GetResourceDataAsync(string.Format("{0}{1}/{2}?apiKey={3}", EthplorerUrl, "getAddressInfo", address, apiKey));
        }

        public async Task<string> GetTokenInformation(string apiKey, string address)
        {
            return "";
        }

        public async Task<string> GetTokenHistory(string apiKey, string networkSymbol, string currencySymbol)
        {
            return await GetResourceDataAsync(string.Format("{0}{1}?fsyms={3}&tsyms={}&api_key=", CryptoCompareUrl, "pricemultifull", networkSymbol, currencySymbol, apiKey));
        }
        #endregion

        #region Utilities
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
