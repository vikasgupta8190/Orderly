using Orderly.Models.Calendar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orderly.Factories.Calendar
{
    public interface ICalendarModelFactory
    {
        Task<CalendarListModel> PrepareCalendarListModelAsync(CalendarSearchModel searchModel);
        Task<CalendarListModel> PrepareUpcomingTokenListModelAsync(CalendarSearchModel searchModel);
        
    }
}
