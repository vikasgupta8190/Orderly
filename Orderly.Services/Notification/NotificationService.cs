using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;
using Orderly.Helpers;
using Orderly.Models.Enums;
using Orderly.Models.Messages;
using Orderly.Services.Logg;
using Orderly.Services.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderly.Services.Notification
{
    public class NotificationService: INotificationService
    {
        #region Fields
        private readonly IHttpContextAccessor _httpContextAccessor;    
        private readonly ITempDataDictionaryFactory _tempDataDictionaryFactory;
        private readonly IApplicationUser _applicationUser;
        private readonly ILoggService _errorLoggService;
        #endregion

        #region Ctor

        public NotificationService(IHttpContextAccessor httpContextAccessor,
            ITempDataDictionaryFactory tempDataDictionaryFactory,
            IApplicationUser applicationUser,
            ILoggService errorLoggService)
        {
            _httpContextAccessor = httpContextAccessor;
            _tempDataDictionaryFactory = tempDataDictionaryFactory;
            _applicationUser = applicationUser;
            _errorLoggService = errorLoggService;
        }

        #endregion

        #region Utilities

        /// <summary>
        /// Save message into TempData
        /// </summary>
        /// <param name="type">Notification type</param>
        /// <param name="message">Message</param>
        /// <param name="encode">A value indicating whether the message should not be encoded</param>
        protected virtual void PrepareTempData(NotifyType type, string message, bool encode = true)
        {
            var context = _httpContextAccessor.HttpContext;
            var tempData = _tempDataDictionaryFactory.GetTempData(context);

            //Messages have stored in a serialized list
            var messages = tempData.ContainsKey(OrderlyDefaults.NotificationListKey)
                ? JsonConvert.DeserializeObject<IList<NotifyData>>(tempData[OrderlyDefaults.NotificationListKey].ToString())
                : new List<NotifyData>();

            messages.Add(new NotifyData
            {
                Message = message,
                Type = type,
                Encode = encode
            });

            tempData[OrderlyDefaults.NotificationListKey] = JsonConvert.SerializeObject(messages);
        }

        /// <summary>
        /// Log exception
        /// </summary>
        /// <param name="exception">Exception</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        protected virtual void LogExceptionAsync(Exception exception)
        {
            if (exception == null)
                return;
            var customer =  _applicationUser.GetCurrentUserAsync().Result;
            _errorLoggService.ErrorAsync(exception, customer);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Display notification
        /// </summary>
        /// <param name="type">Notification type</param>
        /// <param name="message">Message</param>
        /// <param name="encode">A value indicating whether the message should not be encoded</param>
        public virtual void Notification(NotifyType type, string message, bool encode = true)
        {
            PrepareTempData(type, message, encode);
        }

        /// <summary>
        /// Display success notification
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="encode">A value indicating whether the message should not be encoded</param>
        public virtual void SuccessNotification(string message, bool encode = true)
        {
            PrepareTempData(NotifyType.Success, message, encode);
        }

        /// <summary>
        /// Display warning notification
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="encode">A value indicating whether the message should not be encoded</param>
        public virtual void WarningNotification(string message, bool encode = true)
        {
            PrepareTempData(NotifyType.Warning, message, encode);
        }

        /// <summary>
        /// Display error notification
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="encode">A value indicating whether the message should not be encoded</param>
        public virtual void ErrorNotification(string message, bool encode = true)
        {
            PrepareTempData(NotifyType.Error, message, encode);
        }

        /// <summary>
        /// Display error notification
        /// </summary>
        /// <param name="exception">Exception</param>
        /// <param name="logException">A value indicating whether exception should be logged</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual void LogErrorWithNotificationAsync(Exception exception, bool logException = true)
        {
            if (exception == null)
                return;

            if (logException)
                LogExceptionAsync(exception);

            ErrorNotification(StringResources.ErrorMessage);
        }

        #endregion
    }
}
