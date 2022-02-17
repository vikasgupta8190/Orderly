using Microsoft.AspNetCore.Identity;
using Orderly.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderly.Services.User
{
    public interface IApplicationUser
    {
        Task<ApplicationUser> GetCurrentUserAsync();
        Task<bool> UpdatePortfolio(bool isSetup);
    }
}
