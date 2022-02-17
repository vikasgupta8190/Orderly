using Orderly.Core.Domain.Contact;
using Orderly.Models.Comman;
using Orderly.Models.Monitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderly.Services.Monitor
{
    public interface IMonitoringService
    {
        Task<Monitoring> GetMonitoringByIdAsync(int id);
        Task<List<Monitoring>> GetMonitoringsByNetworkIdAsync(int id, int userId);
        Task<IPagedList<Monitoring>> GetMonitoringPagedListByNetworkIdAsync(int id, int userId, int pageIndex = 0, int pageSize = int.MaxValue);
        Task InsertOrUpdateAsync(MonitoringModel model,int userId);
        Task DeleteAsync(int id);
        Task<List<Monitoring>> GetAllMonitoringAsync(int customerId);
        Task MonitorAddress();
        Task DeleteByNetworkIdAsync(int networkId, int userId);
        Task UpdateAllNetworkNotificationAsync(int networkId, int userId, bool enable);
        Task UpdateAllNetworkShowOnPortfolioAsync(int networkId, int userId, bool enable);
        Task UpdateTokenNotificationAsync(int monitoringId, int userId, bool enable);
        Task UpdateTokenGenerationAsync(int monitoringId, int userId, bool enable);
    }
}
