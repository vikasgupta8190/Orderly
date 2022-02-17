using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Orderly.Factories.Calendar;
using Orderly.Models.Calendar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orderly.Controllers
{
    [Authorize]
    public class CalendarController : Controller
    {

        #region Properties
        private readonly ICalendarModelFactory _calendarModelFactory;
        #endregion

        #region Constructor
        public CalendarController(ICalendarModelFactory calendarModelFactory)
        {
            _calendarModelFactory = calendarModelFactory;
        }


        #endregion

        #region Methods
        public IActionResult Index()
        {
            return View(new CalendarSearchModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GetCalendarResults(CalendarSearchModel searchModel)
        {
            var model = await _calendarModelFactory.PrepareCalendarListModelAsync(searchModel);
            return Json(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GetUpcomingtoken(CalendarSearchModel searchModel)
        {
            var model = await _calendarModelFactory.PrepareUpcomingTokenListModelAsync(searchModel);
            return Json(model);
        }
        #endregion
    }
}
