using Orderly.Models.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orderly.Factories.Token
{
    public interface ITokenModelFactory
    {
        Task<TokenListModel> PrepareTokenListModelAsync(TokenSearchModel searchModel);
        Task<TokenManagementModel> PrepareTokenManagementModelAsync(int userId,int id = 0);
    }
}
