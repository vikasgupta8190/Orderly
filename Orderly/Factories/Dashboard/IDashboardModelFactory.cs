using Orderly.Models.Dashboard;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Orderly.Factories.Dashboard
{
    public interface IDashboardModelFactory
    {
        Task<TokenListModel> PrepareTokenListModelAsync(TokenSearchModel searchModel, bool isUpcoming);
        Task<TokenOverviewListModel> PrepareTokenOverviewListModel(TokenSearchModel searchModel);
        Task<List<PieChartModel>> PreparePieChartModelData(int userId, List<int> networkIds);
    }
}
