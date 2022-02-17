using Orderly.Models.Comman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderly.Models.Calendar
{
    public record CalendarModel : BaseEntityModel
    {
        public string Icon { get; set; }
        public string NetworkType { get; set; }
        public string Abbrivation { get; set; }
        public string Stage { get; set; }
        public DateTime Date { get; set; }       
        public decimal Goal { get; set; }
    }

    public record CalendarListModel : BasePagedListModel<CalendarModel>
    {

    }
}
