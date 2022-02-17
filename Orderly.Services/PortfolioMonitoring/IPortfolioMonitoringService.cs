using Orderly.Models.Portfolio;
using System.Collections.Generic;
using System.Threading.Tasks;
using Orderly.Core.Domain.Portfolio;

namespace Orderly.Services.Portfolio
{
    public interface IPortfolioMonitoringService
    {       
        Task DeleteAddressToTableAsync(int addressId,int userId);
        Task AddOrUpdateAddressToTableAsync(List<PortFolioMonitoringModel> monitoringModel);
        Task<List<MonitoringType>> GetAllMonitoringTypesAsync(int? typeId = null);
        Task<List<PortfolioMonitoring>> GetAddressesByMonitoringTypeIdAsync(int id,int currentUserId);
        Task<List<PortfolioMonitoring>> GetAllAddressesByUserIdAsync(int userId);
    }
}
