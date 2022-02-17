using Orderly.Core.Domain.Common;
using Orderly.Core.Domain.Log;
using System;
using System.Threading.Tasks;

namespace Orderly.Services.Logg
{
    public interface ILoggService
    {
        Task<ErrorLog> ErrorAsync(Exception ex, ApplicationUser currentUser);
        Task WarningAsync(string message, ApplicationUser currentUser);
       
    }
}
