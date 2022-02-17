using Orderly.Models.Comman;
using Orderly.Models.Investment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orderly.Factories.Investment
{
    public interface IInvestmentModelFactory
    {
        Task<UserInvestmentModel> PrepareUserInvestmentModelAsync(int userId, int investmentId = 0);
        Task<InvestmentListModel> PrepareInvestmentListModelAsync(InvestmentSearchModel searchModel,int userId);
        Task<UserInvestmentModel> GetByIdAndUserId(int Id, int userId);
    }
}
