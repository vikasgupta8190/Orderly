using Orderly.Models.Comman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderly.Models.Analyzer
{
    public record DistributionTansactionsModel : BaseEntityModel
    {
        public string TransactionHexCode { get; set; }
        public DateTime Date { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public decimal Quantity { get; set; }
        public string NetworkAbbrivation { get; set; }
        public decimal Value { get; set; }
    }
    public record DistributionTansactionsListModel:BasePagedListModel<DistributionTansactionsModel>
    {
    }
}
