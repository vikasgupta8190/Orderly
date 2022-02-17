using Orderly.Models.Comman;

namespace Orderly.Models.Analyzer
{
    public record InvestmentAnalyzerSearchModel : BaseSearchModel
    {
        public int FilterType { get; set; }
        public int FilterValue { get; set; }
        public string Keyword { get; set; }
    }
}
