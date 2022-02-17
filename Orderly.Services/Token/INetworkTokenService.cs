using Orderly.Core.Domain.Tokens;
using Orderly.Models.Comman;
using Orderly.Models.Dashboard;
using Orderly.Models.Tokens;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Orderly.Services.Token
{
    public interface INetworkTokenService
    {
        Task<NetworkToken> GetById(int id);
        //Task<List<NetworkToken>> GetAllTokensPagedListByNetworkId(int networkId);
        Task Delete(int networkId);
        Task InsertOrUpdate(TokenManagementModel model);
        Task<IPagedList<NetworkToken>> GetAllTokensPagedListByNetworkId(int pageNumber = 0,int pageSize = int.MaxValue);
        Task<List<NetworkToken>> GetAll();
        Task<List<NetworkToken>> GetAllByInvestmentId(int investmentId);
        Task<bool> IsTokenExist(string contractAddress);
        Task<NetworkToken> GetByAddress(string address);
        Task UpdateHighAndLowPrice();
        Task<List<NetworkToken>> GetWalletToken(List<int> networkIds,int userId = 0);
        Task<IPagedList<TokenOverviewModel>> GetTokenOverview(int userId, string networkIds, int pageIndex = 0, int pageSize = int.MaxValue);

    }
}
