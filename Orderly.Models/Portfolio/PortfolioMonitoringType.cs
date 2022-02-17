using Orderly.Models.Comman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderly.Models.Portfolio
{
    public partial record PortfolioMonitoringType : BaseEntityModel
    {
        public PortfolioMonitoringType()
        {
            Addresses = new List<PortfolioMonitoringAddress>();
        }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public string Icon { get; set; }
        public List<PortfolioMonitoringAddress> Addresses { get; set; }
    }
}
