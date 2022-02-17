using Orderly.Models.Calendar;
using Orderly.Models.Extensions;
using Orderly.Services.Token;
using Orderly.Services.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orderly.Factories.Calendar
{
    public class CalendarModelFactory : ICalendarModelFactory
    {
        #region Properties
        private readonly ICalendarService _calendarService;
        private readonly IApplicationUser _appUser;
        #endregion

        #region Constructor
        public CalendarModelFactory(ICalendarService calendarService,
            IApplicationUser appUser)
        {
            _calendarService = calendarService;
            _appUser = appUser;
        }
        #endregion

        public async Task<CalendarListModel> PrepareCalendarListModelAsync(CalendarSearchModel searchModel)
        {
            var currentUser = await _appUser.GetCurrentUserAsync();
            var list = await _calendarService.GetPagedListCalendars(currentUser.Id, searchModel.ListType, searchModel.Page - 1, searchModel.PageSize);
            //prepare list model
            var model = new CalendarListModel().PrepareToGrid(searchModel, list, () =>
            {
                return list.Select(x =>
                {
                    return new CalendarModel()
                    {
                        Id = x.Id,
                        Abbrivation = x.Token.Network.Abbreviation,
                        Stage = x.Stage,
                        Icon = x.Token.Network.Icon,
                        NetworkType = x.Token.Name,
                        Date = x.Date,
                        Goal = x.Goal
                    };
                });
            });
            return model;
        }

        public async Task<CalendarListModel> PrepareUpcomingTokenListModelAsync(CalendarSearchModel searchModel)
        {
            var currentUser = await _appUser.GetCurrentUserAsync();
            var list = await _calendarService.GetUpComingTokens(currentUser.Id, searchModel.ListType, searchModel.Page - 1, searchModel.PageSize);
            //prepare list model
            var model = new CalendarListModel().PrepareToGrid(searchModel, list, () =>
            {
                return list.Select(x =>
                {
                    return new CalendarModel()
                    {
                        Id = x.networkTokens.Id,
                        Abbrivation = x.networkTokens.Network.Abbreviation,
                        Icon = x.networkTokens.Network.Icon,
                        NetworkType = x.networkTokens.Name,
                        Goal = x.InvestedAmount
                    };
                });
            });
            return model;
        }
    }
}
