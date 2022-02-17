using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Orderly.Services.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orderly.ActionFilter
{
    public class HandleErrorCustomAttribute : Attribute, IExceptionFilter
    {
        #region Properties
        private readonly INotificationService _notificationSerivce;
        #endregion

        #region Constructor
        public HandleErrorCustomAttribute(INotificationService notificationSerivce)
        {
            _notificationSerivce = notificationSerivce;
        }      
        #endregion

        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            
        }
        
        public void OnException(ExceptionContext context)
        {
            _notificationSerivce.LogErrorWithNotificationAsync(context.Exception);
            context.ExceptionHandled = true;
        }
    }
}
