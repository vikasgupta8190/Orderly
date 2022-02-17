using Orderly.Models.Comman;

namespace Orderly.Models.Analyzer
{
   public record DistributionTransactionSearchModel:BaseSearchModel
    {
        public string TransactionLink { get; set; }
        public int NetworkId { get; set; }
    }
}
