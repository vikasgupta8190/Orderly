using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Orderly.Factories.OverTheCounter;
using Orderly.Helpers;
using Orderly.Models.Comman;
using Orderly.Models.OTC;
using Orderly.Services.Notification;
using Orderly.Services.OverTheCounter;
using Orderly.Services.User;

using System;
using System.Threading.Tasks;

namespace Orderly.Controllers
{
    [Authorize]
    public class OTCController : Controller
    {
        #region Properties
        private readonly IOTCModelFactory _otcModelFactory;
        public readonly INotificationService _notificationService;
        public readonly IOTCService _otcService;
        private readonly IApplicationUser _appUser;
        #endregion

        #region Constructor
        public OTCController(
            INotificationService notificationService,
            IOTCService otcService,
            IOTCModelFactory otcModelFactory,
            IApplicationUser appUser
            )
        {
            _notificationService = notificationService;
            _otcService = otcService;
            _otcModelFactory = otcModelFactory;
            _appUser = appUser;
        }
        #endregion

        #region Method
        public async Task<IActionResult> Index(int id)
        {
            OTCModel oTCModel = new OTCModel();
            try
            {
                await _otcService.ArchiveOTC(Common.OTCArchiveInHours);
                var currentUserId = (await _appUser.GetCurrentUserAsync()).Id;
                oTCModel = await _otcModelFactory.PrepareOTCModel(currentUserId, id);
                if (id > 0)
                    ViewBag.ViewModeEnable = true;
            }
            catch (Exception ex)
            {
                _notificationService.ErrorNotification(ex.Message);
            }
            return View(oTCModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOTC(OTCModel model)
        {
            bool isSuccess = true;
            try
            {
                if (ModelState.IsValid)
                {
                    await _otcService.InsertOrUpdateOTC(model);
                    _notificationService.SuccessNotification(StringResources.AddedSucessMessage);
                }
            }
            catch (Exception ex)
            {
                isSuccess = false;
                _notificationService.ErrorNotification(ex.Message);
            }
            return Json(new { success = isSuccess });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OTCList(OTCSearchModel searchModel)
        {
            var model = await _otcModelFactory.PrepareOTCListModel((await _appUser.GetCurrentUserAsync()).Id, searchModel);
            return Json(model);
        }
        #endregion
    }
}
