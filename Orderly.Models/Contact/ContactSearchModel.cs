using Orderly.Models.Comman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderly.Models.Contact
{
    public record ContactSearchModel : BaseSearchModel
    {
        public bool ShowGroup { get; set; }
    }
}
