using Microsoft.AspNetCore.Identity;
using Orderly.Core.Domain.Common;
using Orderly.Core.Domain.Investment;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderly.Core.Domain.Contact
{
    public class UserContact : BaseEntity
    {
        public UserContact()
        {
            GroupMapping = new List<UserContactGroupMapping>();
            userInvestment = new List<UserInvestment>();
            sharedInvestmentDetails = new List<SharedInvestmentDetails>();
        }
        public string Name { get; set; }
        public string Address { get; set; }  
        public virtual ICollection<UserContactGroupMapping> GroupMapping { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<UserInvestment> userInvestment { get; set; }
        public virtual ICollection<SharedInvestmentDetails> sharedInvestmentDetails { get; set; }
    }
}
