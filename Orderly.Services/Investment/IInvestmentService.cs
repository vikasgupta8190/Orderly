using Orderly.Core.Domain.Investment;
using Orderly.Models.Comman;
using Orderly.Models.Investment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderly.Services.Investment
{
    public interface IInvestmentService
    {
        Task<IList<UserInvestment>> GetInvestmentsByUserIdAsync(int userId);
        Task<UserInvestment> GetByIdAndUserId(int userId, int investmentId);
        Task<int> InsertOrUpdateInvestmentAsync(UserInvestmentModel model);
        Task DeleteInvestmentAsync(int userId, int investmentId);
        Task<UserInvestment> GetInvestmentByGUIDAsync(Guid investmentGUID);
        Task<UserInvestment> GetById(int id);
        Task InsertOrUpdateDynamicDistributionAsync(UserInvestmentModel model, UserInvestment userInvestment = null);
        Task<IPagedList<UserInvestment>> GetInvestmentListByUserIdAsync(int userId, int pageIndex, int pageSize,int filterType = 0, int filterValue = 0,string keyword = "");
        Task Delete(int id);
        Task UpdateRefundAmount(RefundModel refundModel);
        Task UpdateSaftFile(string fileName,string uniqueFileName, int id);
        Task<IList<UserInvestment>> GetInvestmentsByUserIdAndTokenAsync(int userId,int tokenId);
        Task<bool> isTokenAssociated(int tokenId);
        Task<List<UserInvestment>> GetInvestmentsByUserIdAndNetworkIds(int userId, List<int> networkIds);
    }
}
