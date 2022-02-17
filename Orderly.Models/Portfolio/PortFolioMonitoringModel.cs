using Orderly.Models.Comman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderly.Models.Portfolio
{
    public partial record PortFolioMonitoringModel : BaseEntityModel
    {
        public string AddressAlies { get; set; }
        public string Address { get; set; }
        public int TypeId { get; set; }
        public int UserId { get; set; }
        public bool IsSameAddressForBNB { get; set; }
    }
}
