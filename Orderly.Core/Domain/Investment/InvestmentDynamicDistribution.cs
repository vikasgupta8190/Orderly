using Orderly.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderly.Core.Domain.Investment
{
    public class InvestmentDynamicDistribution : BaseEntity
    {        
        public decimal TGE { get; set; }
        public decimal? Peroid { get; set; }
        public decimal? TokenPercentage { get; set; }
        public int? Lookup { get; set; }
        public int? LookupDuration { get; set; }
        public virtual UserInvestment Investment { get; set; }
    }
}
