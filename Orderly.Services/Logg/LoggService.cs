using Microsoft.AspNetCore.Http;

using Orderly.Core.Domain.Common;
using Orderly.Core.Domain.Log;
using Orderly.Repositories;

using System;
using System.Threading.Tasks;

namespace Orderly.Services.Logg
{
    public class LoggService : ILoggService
    {
        #region Properties
        private readonly IRepository<ErrorLog> _errorLogRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        #endregion

        public LoggService(
            IRepository<ErrorLog> errorLogRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            _errorLogRepository = errorLogRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ErrorLog> ErrorAsync(Exception ex, ApplicationUser currentUser)
        {
            ErrorLog errorLog = new ErrorLog();
            errorLog.Message = ex.Message;
            errorLog.Description = ex.StackTrace;
            errorLog.CreatedOn = DateTime.UtcNow;
            errorLog.CreatedBy = currentUser?.Id;
            errorLog.Type = "Error";
            errorLog.PageUrl = GetThisPageUrl(true);
            errorLog.IPAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            await _errorLogRepository.InsertAsync(errorLog);
            return errorLog;
        }

        public Task WarningAsync(string message, ApplicationUser currentUser)
        {
            throw new NotImplementedException();
        }

        protected virtual string GetThisPageUrl(bool includeQueryString, bool? useSsl = null, bool lowercaseUrl = false)
        {
            if (!IsRequestAvailable())
                return string.Empty;

         
            //add local path to the URL
            var pageUrl = $"{_httpContextAccessor.HttpContext.Request.Path}";

            //add query string to the URL
            if (includeQueryString)
                pageUrl = $"{pageUrl}{_httpContextAccessor.HttpContext.Request.QueryString}";

            //whether to convert the URL to lower case
            if (lowercaseUrl)
                pageUrl = pageUrl.ToLowerInvariant();

            return pageUrl;
        }

        /// <summary>
        /// Check whether current HTTP request is available
        /// </summary>
        /// <returns>True if available; otherwise false</returns>
        protected virtual bool IsRequestAvailable()
        {
            if (_httpContextAccessor?.HttpContext == null)
                return false;
            try
            {
                if (_httpContextAccessor.HttpContext.Request == null)
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
