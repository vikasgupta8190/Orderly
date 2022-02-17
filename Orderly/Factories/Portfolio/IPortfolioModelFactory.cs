using Orderly.Models.Portfolio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orderly.Factories.Portfolio
{
    public interface IPortfolioModelFactory
    {
        Task<List<PortfolioMonitoringType>> PreparePortfolioMonitoringTypesModelAsync(int currentUserId, int? type, string searchKey = null);
    }
}
