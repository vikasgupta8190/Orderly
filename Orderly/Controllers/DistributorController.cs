using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Orderly.Factories.Contact;
using Orderly.Factories.Distributor;
using Orderly.Helpers;
using Orderly.Models.Distributor;
using Orderly.Services.Comman;
using Orderly.Services.Notification;
using Orderly.Services.User;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orderly.Controllers
{
    [Authorize]
    public class DistributorController : Controller
    {
        #region Properties
        private readonly IDistributorModelFactory _distributorModelFactory;
        private readonly ICommanService _commanService;
        private readonly IApplicationUser _appUser;
        private readonly INotificationService _notificatonService;
        private readonly IContactModelFactory _contactModelFactory;
        #endregion

        #region Constructor
        public DistributorController(
            IDistributorModelFactory distributorModelFactory,
            ICommanService commanService,
            IApplicationUser appUser,
            INotificationService notificationService,
            IContactModelFactory contactModelFactory
            )
        {
            _distributorModelFactory = distributorModelFactory;
            _commanService = commanService;
            _appUser = appUser;
            _notificatonService = notificationService;
            _contactModelFactory = contactModelFactory;
        }
        #endregion
        public async Task<IActionResult> Index()
        {
            var model = await _contactModelFactory.PrepareContactModelAsync();
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> List(TransactionDetailSearchModel searchModel)
        {           
            var model = await _distributorModelFactory.PrepareTransactionDetailListModelAsync(searchModel);
            return Json(model);
        }
    }
}
