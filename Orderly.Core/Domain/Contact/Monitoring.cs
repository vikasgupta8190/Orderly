using Orderly.Core.Domain.Common;
using Orderly.Core.Domain.Portfolio;
using Orderly.Core.Domain.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderly.Core.Domain.Contact
{
    public class Monitoring : BaseEntity
    {
        public bool IncommingTokenNotificationEvent { get; set; }
        public bool TokenGenerationNotificationEvent { get; set; }
        public int UserId { get; set; }
        public int? PortfolioMonitoringId { get; set; }
        public bool ShowInPortfolio { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual PortfolioMonitoring PortfolioMonitoring { get; set; }
    }
}
