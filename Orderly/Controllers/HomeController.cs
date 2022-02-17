using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

using Orderly.Factories.Calendar;
using Orderly.Factories.Dashboard;
using Orderly.Models;
using Orderly.Models.Dashboard;
using Orderly.Services.Dashboard;
using Orderly.Services.Portfolio;
using Orderly.Services.Token;
using Orderly.Services.User;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Orderly.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDashboardService _dashboardService;
        private readonly ICalendarService _calendarService;
        private readonly IDashboardModelFactory _dashboardModelFactory;
        private readonly IApplicationUser _appUser;
        private readonly IPortfolioMonitoringService _portfolioMonitoringService;

        public HomeController(ILogger<HomeController> logger,
            IDashboardService dashboardService,
            IApplicationUser appUser,
            ICalendarService calendarService,
            IDashboardModelFactory dashboardModelFactory,
            IPortfolioMonitoringService portfolioMonitoringService)
        {
            _logger = logger;
            _dashboardService = dashboardService;
            _appUser = appUser;
            _calendarService = calendarService;
            _dashboardModelFactory = dashboardModelFactory;
            _portfolioMonitoringService = portfolioMonitoringService;
        }

        public async Task<ActionResult> Index(string v)
        {
            DashboardModel dashboardModel = new DashboardModel();
            var userId = _appUser.GetCurrentUserAsync().Result.Id;
            var types = await _portfolioMonitoringService.GetAllMonitoringTypesAsync();
            List<int> networkIds = new List<int>();
            string[] ids = null;
            dashboardModel.TokenSearchModel = new TokenSearchModel();
            if (!string.IsNullOrEmpty(v))
            {
                ids = v.Split(",");
                if (ids.Length > 1)
                {
                    var listOfArray = ids.Select(n => Convert.ToInt32(n)).ToList();
                    networkIds.AddRange(listOfArray);
                }
                else
                {
                    var value = Convert.ToInt32(ids[0]);
                    if (value == 0)
                    {
                        networkIds.AddRange(types.Select(x => x.Id).ToList());
                    }
                    else
                    {
                        networkIds.Add(Convert.ToInt32(ids[0]));
                    }
                }
            }
            else
            {
                networkIds.AddRange(types.Select(x => x.Id).ToList());
            }
            dashboardModel = await _dashboardService.BindData(userId, networkIds);
            if (ids != null)
            {
                if (ids[0] == "0")
                {
                    dashboardModel.AvailableNetworks.Add(new SelectListItem() { Text = "Show All", Value = "0", Selected = true });
                }
                else
                {
                    dashboardModel.AvailableNetworks.Add(new SelectListItem() { Text = "Show All", Value = "0" });
                }
            }
            else
            {
                dashboardModel.AvailableNetworks.Add(new SelectListItem() { Text = "Show All", Value = "0" });
            }

            dashboardModel.AvailableNetworks.AddRange(types.Select(x => new SelectListItem()
            {
                Text = x.Type,
                Value = x.Id.ToString(),
                Selected = ids != null ? Array.Exists(ids, y => y == x.Id.ToString()) : false
            }).ToList());
            if (!string.IsNullOrEmpty(v))
            {
                dashboardModel.TokenSearchModel.NetworkId = v;
            }
            return View(dashboardModel);
        }

        public async Task<ActionResult> SetupPortfolio()
        {
            var user = await _appUser.UpdatePortfolio(true);
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GetToken(TokenSearchModel searchModel, bool isUpcoming)
        {
            var model = await _dashboardModelFactory.PrepareTokenListModelAsync(searchModel, isUpcoming);
            return Json(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GetTokenOverView(TokenSearchModel searchModel)
        {
            var model = await _dashboardModelFactory.PrepareTokenOverviewListModel(searchModel);
            return Json(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetPieChartData(string networkId)
        {
            List<int> networkIds = new List<int>();
            if (!string.IsNullOrEmpty(networkId))
            {
                var ids = networkId.Split(",");
                if (ids.Length > 1)
                {
                    var listOfArray = ids.Select(n => Convert.ToInt32(n)).ToList();
                    networkIds.AddRange(listOfArray);
                }
                else
                {
                    var value = Convert.ToInt32(ids[0]);
                    if (value == 0)
                    {
                        await AllNetworkIds(out networkIds);
                    }
                    else
                    {
                        networkIds.Add(Convert.ToInt32(ids[0]));
                    }
                }
            }
            else
            {
                await AllNetworkIds(out networkIds);
            }
            var currentUser = await _appUser.GetCurrentUserAsync();
            var model = await _dashboardModelFactory.PreparePieChartModelData(currentUser.Id, networkIds);
            return Json(model);
        }

        private Task AllNetworkIds(out List<int> networkIds)
        {
            networkIds = new List<int>();
            var types = _portfolioMonitoringService.GetAllMonitoringTypesAsync().Result;
            networkIds.AddRange(types.Select(x => x.Id).ToList());
            return Task.CompletedTask;
        }
    }
}
