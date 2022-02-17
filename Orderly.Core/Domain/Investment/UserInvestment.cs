using Orderly.Core.Domain.Common;
using Orderly.Core.Domain.Contact;
using Orderly.Core.Domain.Portfolio;
using Orderly.Core.Domain.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Orderly.Core.Domain.Investment
{
    public class UserInvestment : BaseEntity
    {
        public UserInvestment()
        {
            DynamicDistributions = new List<InvestmentDynamicDistribution>();
            sharedInvestmentDetails = new List<SharedInvestmentDetails>();
        }
        public Guid InvestmentGUID { get; set; }
        public decimal InvestedAmount { get; set; }
        public string InvestmentTransactionLink { get; set; }
        public decimal VestingLockup { get; set; }
        public decimal VestingTokenPercentage { get; set; }
        public int VestingId { get; set; }
        public int DistributionTypeId { get; set; }
        public int InvestmentTypeId { get; set; }
        public string SaftFile { get; set; }
        public string SaftPathSavedFileName { get; set; }
        public string WebsiteLink { get; set; }
        public string Sign { get; set; }       
        public int? ContactId { get; set; }
        public string DistributionPortal { get; set; }
        public string CustomLink { get; set; }
        public virtual int MonitoringTypeId { get; set; }
        public decimal RefundAmount { get; set; }
        public DateTime CreatedOnDateTimeUTC { get; set; }
        public DateTime UpdatedOnDateTimeUTC { get; set; }
        public string InvestedQuantity { get; set; }
        public int? TokenId { get; set; }
        public int NumberOfToken { get; set; }
        public string SentAddressFrom { get; set; }
        public virtual MonitoringType MonitoringType { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<InvestmentDynamicDistribution> DynamicDistributions { get; set; }
        [ForeignKey("ContactId")]
        public virtual UserContact UserContact { get; set; }
        public virtual ICollection<SharedInvestmentDetails> sharedInvestmentDetails { get; set; }
        [ForeignKey("TokenId")]
        public virtual NetworkToken networkTokens { get; set; }


    }
}
