using Orderly.Models.Comman;
using Orderly.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderly.Models.Calendar
{
    public record CalendarSearchModel : BaseSearchModel
    {
        public CalendarTypes ListType { get; set; }
    }
}
