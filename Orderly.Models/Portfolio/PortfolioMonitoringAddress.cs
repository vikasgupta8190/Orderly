using Orderly.Models.Comman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderly.Models.Portfolio
{
    public partial record PortfolioMonitoringAddress : BaseEntityModel
    {
        public string Address { get; set; }
        public string Alies { get; set; }
    }
}
