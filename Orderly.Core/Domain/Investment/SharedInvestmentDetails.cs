using Orderly.Core.Domain.Common;
using Orderly.Core.Domain.Contact;

using System.ComponentModel.DataAnnotations.Schema;

namespace Orderly.Core.Domain.Investment
{
    public class SharedInvestmentDetails:BaseEntity
    {
        public int InvestmentId { get; set; }
        public int ContactId { get; set; }
        public decimal Percentage { get; set; }
        [ForeignKey("ContactId")]
        public virtual UserContact Contact { get; set; }
        [ForeignKey("InvestmentId")]
        public virtual UserInvestment Investment { get; set; }

    }
}
