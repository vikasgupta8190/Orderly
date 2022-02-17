using Orderly.Models.Comman;

using System;

namespace Orderly.Models.Analyzer
{
    public partial record InvestmentAnalyzerModel : BaseEntityModel
    {
        public InvestmentAnalyzerModel()
        {
            SearchModel = new InvestmentAnalyzerSearchModel();
        }
        public decimal InvestedAmount { get; set; }
        public decimal InvestedQuantity { get; set; }
        public string InvestementAbbrivation { get; set; }

        public string InvestmentTransactionLink { get; set; }
        public string InvestedNetworkIcon { get; set; }
        public decimal ProfitOrLossPercentage { get; set; }
        public decimal VestingLockup { get; set; }
        public decimal VestingTokenPercentage { get; set; }
        public int VestingId { get; set; }
        public int DistributionTypeId { get; set; }
        public int InvestmentTypeId { get; set; }
        public string Address { get; set; }
        public string Sign { get; set; }
        public virtual int MonitoringTypeId { get; set; }
        public DateTime CreatedOnDateTimeUTC { get; set; }
        public DateTime UpdatedOnDateTimeUTC { get; set; }
        public InvestmentAnalyzerSearchModel SearchModel { get; set; }
        public decimal CurrentAmountOfInvestedAmount { get; set; }

    }

    public record InvestmentAnalyzerListModel : BasePagedListModel<InvestmentAnalyzerModel>
    {
        public decimal WholeTimeInvestedAmount { get; set; }
        public decimal CurrentAmountOfInvestedAmt { get; set; }
        public string profitLossOnInvestment { get; set; }
    }
}
