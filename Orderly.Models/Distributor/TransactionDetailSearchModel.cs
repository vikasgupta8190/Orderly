using Microsoft.AspNetCore.Mvc.Rendering;

using Orderly.Models.Comman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderly.Models.Distributor
{
    public record TransactionDetailSearchModel : BaseSearchModel
    {
        public TransactionDetailSearchModel()
        {
            AvailableTokensTypes = new List<SelectListItem>();
        }
        public string FilterType { get; set; }
        public string Address { get; set; }
        public int TokensType { get; set; }
        public List<SelectListItem> AvailableTokensTypes { get; set; }
        public DateTime? AnyPeriod { get; set; }
    }
}
