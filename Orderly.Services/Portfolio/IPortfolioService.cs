using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderly.Services.Portfolio
{
    public interface IPortfolioService
    {
        Task<string> ValidateAddressAsync(string address, string apiKey);
        Task<string> ValidateInvestmentTransactionLinkAsync(string address, string apiKey);
        Task<string> GetCurrencyRate(string apiKey);
        Task<string> ValidateContractAsync(string address, string apiKey);
        Task<string> GetDetailByTransactionLink(string link, string apiKey);
        Task<string> GetTransactionDetailByContractIdAndAddress(string contractId, string addressId, string apiKey, int page = 1, int pageOffset = 9999);
        Task<string> GetTransactionListByUserAddress(string address, string apiKey, DateTime? startDate = null, DateTime? endDate = null);//,int pageNumber=1,int pageSize=int.MaxValue);
        Task<string> GetTransactionlistByTransactionLink(string transctionLink, string apiKey, DateTime? startDate = null, DateTime? endDate = null);//,int pageNumber=1,int pageSize=int.MaxValue);
        Task<string> GetDailyCurrency(string apiKey, DateTime startDate, DateTime endDate);
        Task<string> GetTokenInfo(string apiKey, string contractAddress);
        Task<string> GetAllTokenByAddress(string apiKey, string address);
        Task<string> GetTokenInformation(string apiKey, string address);
        Task<string> GetTokenHistory(string apiKey, string networkSymbol, string currencySymbol);


    }
}
