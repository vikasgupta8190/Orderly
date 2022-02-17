using Microsoft.AspNetCore.Identity;
using Orderly.Core.Domain.Common;
using Orderly.Core.Domain.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderly.Core.Domain.Portfolio
{
    public partial class PortfolioMonitoring : BaseEntity
    {
        public int TokenId { get; set; }        
        public string Address { get; set; }
        public string AddressAlias { get; set; }
        public virtual MonitoringType MonitoringType { get; set; }
        public virtual Monitoring Monitoring { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
