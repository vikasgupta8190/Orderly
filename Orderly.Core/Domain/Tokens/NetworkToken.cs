using Orderly.Core.Domain.Common;
using Orderly.Core.Domain.Investment;
using Orderly.Core.Domain.OverTheCounter;
using Orderly.Core.Domain.Portfolio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace Orderly.Core.Domain.Tokens
{
    public class NetworkToken : BaseEntity
    {
        public NetworkToken()
        {
            userInvestment = new List<UserInvestment>();
            otc = new List<OTC>();
        }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public string Address { get; set; }       
        public int NetworkId { get; set; }       
        public int? UserId { get; set; }
        public decimal? CurrentPriceUSD { get; set; }
        public decimal? Price24HrsDifference { get; set; }
        public decimal? AllTimeHighValue { get; set; }
        public decimal? AllTimeLowValue { get; set; }
        public DateTime CreatedOnDateTimeUTC { get; set; }
        public DateTime UpdatedOnDateTimeUTC { get; set; }
        public bool? IsShowInPortfolio { get; set; }
        public bool? IsNotificationSet { get; set; }
        [ForeignKey("NetworkId")]
        public virtual MonitoringType Network { get; set; }
        public virtual ICollection<UserInvestment> userInvestment { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<Calendar> Calendars { get; set; }
        public virtual ICollection<OTC> otc { get; set; }
    }
}
