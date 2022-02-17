using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orderly.Controllers
{
    public class CommonController : Controller
    {
        [HttpGet]
        public IActionResult GetNotificationHtml()
        {
            return PartialView("_Notifications");
        }
    }
}
