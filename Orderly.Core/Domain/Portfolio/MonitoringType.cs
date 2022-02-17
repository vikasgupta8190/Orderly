using Orderly.Core.Domain.Common;
using Orderly.Core.Domain.Investment;
using Orderly.Core.Domain.Tokens;
using System.Collections.Generic;

namespace Orderly.Core.Domain.Portfolio
{
    public partial class MonitoringType : BaseEntity
    {        
        public string Type { get; set; }
        public string Abbreviation { get; set; }
        public string Icon { get; set; }
        public virtual UserInvestment Investment { get; set; }
        public virtual ICollection<NetworkToken> Tokens { get; set; }
    }
}
