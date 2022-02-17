using Orderly.Models.Distributor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orderly.Factories.Distributor
{
    public interface IDistributorModelFactory
    {
        Task<TransactionDetailModelList> PrepareTransactionDetailListModelAsync(TransactionDetailSearchModel searchModel);
        Task<DistributorAddressesModel> PrepareAddressModelAsync(int userId);
    }
}
