using Orderly.Core.Domain.Investment;
using Orderly.Core.Domain.Tokens;
using Orderly.Models.Comman;
using Orderly.Models.Dashboard;
using Orderly.Models.Enums;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderly.Services.Token
{
    public interface ICalendarService
    {
        Task<IPagedList<Calendar>> GetPagedListCalendars(int userId, CalendarTypes type, int pageIndex = 0, int pageSize = int.MaxValue);
        Task<List<Calendar>> GetListCalendars(int userId, CalendarTypes type);
        Task<IPagedList<UserInvestment>> GetUpComingTokens(int userId, CalendarTypes type, int pageIndex = 0, int pageSize = int.MaxValue);
        Task<IPagedList<TokenModel>> GetCalendarsTokens(int userId, bool isUpcoming,string networkIds,int nextDays,int prevDays,int pageSize = int.MaxValue, int pageIndex = 0);
    
    }
}
