using Microsoft.AspNetCore.Identity;
using Orderly.Core.Domain.Contact;
using Orderly.Core.Domain.Investment;
using Orderly.Core.Domain.Portfolio;
using Orderly.Core.Domain.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderly.Core.Domain.Common
{
    public class ApplicationUser: IdentityUser<int>
    {
        public ApplicationUser()
        {
            Contacts = new List<UserContact>();
            Groups = new List<UserGroup>();
            Investments = new List<UserInvestment>();
            Portfolios = new List<PortfolioMonitoring>();
        }
        public bool IsPortfolioSetup { get; set; }
        public virtual ICollection<UserContact> Contacts { get; set; }
        public virtual ICollection<UserGroup> Groups { get; set; }
        public virtual ICollection<Monitoring> Monitorings { get; set; }
        public virtual ICollection<UserInvestment> Investments { get; set; }
        public virtual ICollection<PortfolioMonitoring> Portfolios { get; set; }
        public virtual ICollection<NetworkToken> NetworkTokens { get; set; }
    }
}
