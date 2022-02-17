using Orderly.Models.Dashboard;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Orderly.Services.Dashboard
{
    public interface IDashboardService
    {
        Task<DashboardModel> BindData(int userId, List<int> networkIds);
    }
}
