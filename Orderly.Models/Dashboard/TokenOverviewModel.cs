using Orderly.Models.Comman;
using System;

namespace Orderly.Models.Dashboard
{
    public record TokenOverviewModel : BaseEntityModel
    {
        public string TokenName { get; set; }
        public decimal? TokenPrice { get; set; }
        public decimal? TokenUpDown { get; set; }
        public decimal TokenHolding { get; set; }
        public decimal TokenProfitLoss { get; set; }
    }
}
