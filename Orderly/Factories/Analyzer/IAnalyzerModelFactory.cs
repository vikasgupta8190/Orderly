using Microsoft.AspNetCore.Mvc.Rendering;

using Orderly.Models.Analyzer;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Orderly.Factories.Analyzer
{
    public interface IAnalyzerModelFactory
    {
        Task<InvestmentAnalyzerListModel> PrepareInvestmentAnalyzerListModelAsync(InvestmentAnalyzerSearchModel searchModel);
        Task<DistributionTansactionsListModel> PrepareInvestmentDistributionListModelAsync(DistributionTransactionSearchModel searchModel);
        Task<List<SelectListItem>> GetFiltersData(int filterType);
        Task<Dictionary<string, decimal>> PrepareGraphDataAsync(string dateRange);
    }
}
