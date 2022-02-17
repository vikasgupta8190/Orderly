using Orderly.Models.Monitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orderly.Factories.Monitor
{
    public interface IMonitoringModelFactory
    {
        Task<MonitoringListModel> PrepareMonitoringListModelAsync(int networkId, int userId, MonitoringSearchModel searchModel);
        Task<MonitorModel> PrepareMonitorModelAsync(int userId);
    }
}
