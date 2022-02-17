using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Orderly.Factories.Monitor;
using Orderly.Helpers;
using Orderly.Models.Monitor;
using Orderly.Services.Monitor;
using Orderly.Services.Notification;
using Orderly.Services.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orderly.Controllers
{
    [Authorize]
    public class MonitoringController : Controller
    {
        #region Properties
        private readonly IMonitoringService _monitoringService;
        private readonly IApplicationUser _appUser;
        private readonly IMonitoringModelFactory _monitoringModelFactory;
        private readonly INotificationService _notificationService;
        #endregion

        #region Constructor
        public MonitoringController(IMonitoringService monitoringService,
            IApplicationUser appUser,
            IMonitoringModelFactory monitoringModelFactory,
            INotificationService notificationService)
        {
            _monitoringService = monitoringService;
            _appUser = appUser;
            _monitoringModelFactory = monitoringModelFactory;
            _notificationService = notificationService;
        }
        #endregion
        public async Task<IActionResult> Index()
        {
            var currentUser = await _appUser.GetCurrentUserAsync();
            var model = await _monitoringModelFactory.PrepareMonitorModelAsync(currentUser.Id);
            var allmonitoring = (await _monitoringService.GetAllMonitoringAsync(currentUser.Id));
            ViewBag.HasMonitoring = allmonitoring.Any();
            ViewBag.DistinctMonitoringNetworks = allmonitoring.Select(x => x.PortfolioMonitoring.MonitoringType).Distinct().ToList();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveMonitoring(MonitorModel model)
        {
            if (model.ids.Any())
            {
                var currentUser = await _appUser.GetCurrentUserAsync();
                await _monitoringService.InsertOrUpdateAsync(new MonitoringModel()
                {
                    AddressIds = model.ids,
                    IncommingTokenNotificationEvent = true,
                    TokenGenerationNotificationEvent = true,
                    ShowInPortfolio = false,
                    Notification = true
                }, currentUser.Id);
                _notificationService.SuccessNotification(StringResources.AddedSucessMessage);
            }
            return RedirectToRoute("Monitoring");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GetMonitroing(int networkId, MonitoringSearchModel searchModel)
        {
            var currentUser = await _appUser.GetCurrentUserAsync();
            var model = await _monitoringModelFactory.PrepareMonitoringListModelAsync(networkId, currentUser.Id, searchModel);
            return Json(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteMonitoring(int id)
        {
            var currentUser = await _appUser.GetCurrentUserAsync();
            await _monitoringService.DeleteByNetworkIdAsync(id, currentUser.Id);
            _notificationService.SuccessNotification(StringResources.DeleteMessage);
            return Json(new { success = true });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateNotification(int id, bool enable)
        {
            var currentUser = await _appUser.GetCurrentUserAsync();
            await _monitoringService.UpdateAllNetworkNotificationAsync(id, currentUser.Id, enable);
            _notificationService.SuccessNotification(StringResources.UpdateSuccessMessage);
            return Json(new { success = true });
        } 
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TurnOnOffIncommingNotifications(int id, bool enable)
        {
            var currentUser = await _appUser.GetCurrentUserAsync();
            await _monitoringService.UpdateTokenNotificationAsync(id, currentUser.Id, enable);
            _notificationService.SuccessNotification(StringResources.UpdateSuccessMessage);
            return Json(new { success = true });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TurnOnOffTokenGenerationNotifications(int id, bool enable)
        {
            var currentUser = await _appUser.GetCurrentUserAsync();
            await _monitoringService.UpdateTokenGenerationAsync(id, currentUser.Id, enable);
            _notificationService.SuccessNotification(StringResources.UpdateSuccessMessage);
            return Json(new { success = true });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateShowOnPortfolio(int id, bool enable)
        {
            var currentUser = await _appUser.GetCurrentUserAsync();
            await _monitoringService.UpdateAllNetworkShowOnPortfolioAsync(id, currentUser.Id, enable);
            _notificationService.SuccessNotification(StringResources.UpdateSuccessMessage);
            return Json(new { success = true });
        }
    }
}
