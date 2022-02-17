using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Orderly.ActionFilter;
using Orderly.Factories.Contact;
using Orderly.Helpers;
using Orderly.Models.Contact;
using Orderly.Services.Contact;
using Orderly.Services.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orderly.Controllers
{
    [Authorize]
    [TypeFilter(typeof(HandleErrorCustomAttribute))]
   public class ContactsController : Controller
    {
        #region Properties
        private readonly IContactModelFactory _contactModelFactory;
        private readonly IContactService _contactService;
        private readonly INotificationService _notificatonService;
        #endregion

        #region Constructor
        public ContactsController(IContactModelFactory contactModelFactory,
            IContactService contactService,
            INotificationService notificatonService)
        {
            _contactModelFactory = contactModelFactory;
            _contactService = contactService;
            _notificatonService = notificatonService;
        }
        #endregion
        public async Task<IActionResult> Index()
        {
            ViewBag.ShowButtons = true;
            var model = await _contactModelFactory.PrepareContactModelAsync();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddContact(ContactModel model)
        {
            bool hasError = false;
            try
            {
                if (ModelState.IsValid)
                {
                    _notificatonService.SuccessNotification(StringResources.AddedSucessMessage);
                    await _contactService.InsertOrUpdateUserContactAsync(model);
                }
            }
            catch (Exception ex)
            {
                hasError = true;
                _notificatonService.ErrorNotification(ex.Message);
            }
            return Json(new { success = !hasError });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddGroup(UserGroupModel model)
        {
            bool hasError = false;
            try
            {
                if (ModelState.IsValid)
                {
                    await _contactService.InsertOrUpdateUserGroupAsync(model);
                    _notificatonService.SuccessNotification(StringResources.AddedSucessMessage);
                }
            }
            catch (Exception ex)
            {
                hasError = true;
                _notificatonService.ErrorNotification(ex.Message);
            }
            return Json(new { success = !hasError });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ContactList(ContactSearchModel searchModel)
        {
            var model = await _contactModelFactory.PrepareContactListModelAsync(searchModel);
            return Json(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GroupList(ContactSearchModel searchModel)
        {
            var model = await _contactModelFactory.PrepareGroupListModelAsync(searchModel);
            return Json(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task DeleteContact(int id)
        {
            try
            {
                await _contactService.DeleteUserContactAsync(id);
                _notificatonService.SuccessNotification(StringResources.DeleteMessage);
            }
            catch (Exception ex)
            {
                _notificatonService.ErrorNotification(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task DeleteGroup(int id)
        {
            try
            {
                await _contactService.DeleteUserGroupAsync(id);
                _notificatonService.SuccessNotification(StringResources.DeleteMessage);
            }
            catch (Exception ex)
            {
                _notificatonService.ErrorNotification(ex.Message);
            }
        }

        public async Task<IActionResult> EditContact(int id)
        {
            try
            {
                ViewBag.ShowButtons = false;
                var model = await _contactModelFactory.PrepareContactModelAsync(id);
                return View("Index", model);
            }
            catch (Exception ex)
            {
                _notificatonService.ErrorNotification(ex.Message);
            }
            return RedirectToRoute("Contacts");
        }

        public async Task<IActionResult> EditGroup(int id)
        {
            try
            {
                ViewBag.ShowButtons = false;
                ViewBag.GroupModel = await _contactModelFactory.PrepareGroupModelAsync(id);

            }
            catch (Exception ex)
            {
                _notificatonService.ErrorNotification(ex.Message);
            }
            var model = await _contactModelFactory.PrepareContactModelAsync();
            return View("Index", model);

        }
    }
}
