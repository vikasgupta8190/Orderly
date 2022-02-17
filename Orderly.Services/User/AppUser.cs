using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

using Orderly.Core.Domain.Common;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderly.Services.User
{
    public class AppUser : IApplicationUser
    {
        #region Properties
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<ApplicationUser> _userManager;
        #endregion

        #region Constructor
        public AppUser(IHttpContextAccessor httpContextAccessor,
            UserManager<ApplicationUser> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }
        #endregion

        #region Methods
        public async Task<ApplicationUser> GetCurrentUserAsync()
        {
            var user = _httpContextAccessor.HttpContext?.User;

            if (user == null)
            {
                return null;
            }

            return await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
        }

        public async Task<bool> UpdatePortfolio(bool isSetup)
        {
            try
            {
                var userData = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
                userData.IsPortfolioSetup = isSetup;
                await _userManager.UpdateAsync(userData);
                return true;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                return false;
            }
        }
        #endregion
    }
}
