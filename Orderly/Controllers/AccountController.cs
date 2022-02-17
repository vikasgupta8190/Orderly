using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Orderly.Factories.Portfolio;
using Orderly.Helpers;
using Orderly.Models.User;
using Orderly.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Extensions;
using Orderly.Core.Domain.Common;
using Orderly.Services.Notification;
using Orderly.Models.Portfolio;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.IO;
using Microsoft.AspNetCore.Mvc.Razor;

namespace Orderly.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IPortfolioModelFactory _portfolioModelFactory;
        private readonly INotificationService _notificatonService;
        private readonly IRazorViewEngine _razorViewEngine;
        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IPortfolioModelFactory portfolioModelFactory,
            INotificationService notificationService,
            IRazorViewEngine razorViewEngine)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this._portfolioModelFactory = portfolioModelFactory;
            _notificatonService = notificationService;
            _razorViewEngine = razorViewEngine;
        }

        [AllowAnonymous]
        public ActionResult Signup()
        {
            SignupViewModel signupViewModel = new SignupViewModel();
            return View(signupViewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Signup(SignupViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                var existUser = await userManager.FindByEmailAsync(model.Email);
                if (existUser != null)
                {
                    model.Message = "Email already exist";
                    return View(model);
                }
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    NormalizedUserName = model.Email,
                    Email = model.Email,
                    EmailConfirmed = false,
                };
                await userManager.CreateAsync(user);
                var encryptedUserId = EncryptHelper.Encrypt(user.Id.ToString(), Common.EncryptionKey.ToString());
                var callbackUrl = Url.RouteUrl("RegisterAccount", new { userId = encryptedUserId }, protocol: HttpContext.Request.Scheme);
                Common.SendEmail(model.Email, "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>", "Confirm your account");
                return RedirectToRoute("SignupConfirmation", new { email = model.Email });
            }
            catch (Exception ex)
            {
                _notificatonService.LogErrorWithNotificationAsync(ex);
                return RedirectToAction("Signup");
            }
        }

        [AllowAnonymous]
        public ActionResult SignupConfirmation(string email)
        {
            SignupViewModel signupViewModel = new SignupViewModel();
            try
            {
                signupViewModel.Email = email;
            }
            catch (Exception ex)
            {
                _notificatonService.LogErrorWithNotificationAsync(ex);
            }
            return View(signupViewModel);
        }

        [HttpGet, AllowAnonymous]
        public IActionResult Register(string userId)
        {
            RegisterViewModel registerViewModel = new RegisterViewModel();
            try
            {
                registerViewModel.UserId = userId;
            }
            catch (Exception ex)
            {
                _notificatonService.LogErrorWithNotificationAsync(ex);
            }
            return View(registerViewModel);
        }

        [HttpPost, AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string decryptUserId = EncryptHelper.Decrypt(model.UserId, Common.EncryptionKey.ToString());
                    var user = await userManager.FindByIdAsync(decryptUserId);
                    var token = await userManager.GeneratePasswordResetTokenAsync(user);
                    var result = await userManager.ResetPasswordAsync(user, token, model.Password);
                    if (result.Succeeded)
                    {
                        string code = await userManager.GenerateEmailConfirmationTokenAsync(user);
                        var confirmAccount = await userManager.ConfirmEmailAsync(user, code);
                        await signInManager.SignInAsync(user, isPersistent: false);
                        return RedirectToRoute("SetupPortfolioMonitoring");
                    }
                    AddErrors(result);
                }
            }
            catch (Exception ex)
            {
                _notificatonService.LogErrorWithNotificationAsync(ex);
                var error = ex.Message;
            }
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string ReturnUrl = "")
        {
            if (signInManager.IsSignedIn(User))
                return RedirectToRoute("Home");
            UserLoginModel model = new UserLoginModel();
            model.ReturnUrl = ReturnUrl;
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLoginModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await userManager.FindByEmailAsync(model.Email);
                    if (user != null && !user.EmailConfirmed)
                    {
                        var encryptedUserId = EncryptHelper.Encrypt(user.Id.ToString(), Common.EncryptionKey.ToString());
                        var emailVerificationLink = Url.RouteUrl("SendEmailVerificationLink", new { id = encryptedUserId });
                        //ModelState.AddModelError("message", "Email not confirmed yet. Please check your email and confirm your email address or <a href=" + emailVerificationLink + ">click here</a> to resend verify link.");
                        ViewBag.EmailNotConfirmed = "Email not confirmed yet. Please check your email and confirm your email address or <a href=" + emailVerificationLink + ">click here</a> to resend verify link.";
                        return View(model);
                    }
                    if (await userManager.CheckPasswordAsync(user, model.Password) == false)
                    {
                        ModelState.AddModelError("message", "Invalid credentials");
                        return View(model);

                    }

                    var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, true);

                    if (result.Succeeded)
                    {
                        if (Url.IsLocalUrl(model.ReturnUrl))
                        {
                            return Redirect(model.ReturnUrl);
                        }
                        else
                        {
                            await userManager.AddClaimAsync(user, new Claim("UserRole", "Admin"));
                            if (user.IsPortfolioSetup)
                            {
                                return RedirectToRoute("Home");
                            }
                            else
                            {
                                return RedirectToRoute("SetupPortfolioMonitoring");
                            }
                        }
                    }
                    else if (result.IsLockedOut)
                    {
                        return View("AccountLocked");
                    }
                    else
                    {
                        ModelState.AddModelError("message", "Invalid login attempt");
                        return View(model);
                    }
                }
                catch (Exception ex)
                {
                    _notificatonService.LogErrorWithNotificationAsync(ex);
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            try
            {
                await signInManager.SignOutAsync();
            }
            catch (Exception ex)
            {
                _notificatonService.LogErrorWithNotificationAsync(ex);
            }
            return RedirectToRoute("Login");
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        //[AllowAnonymous]
        public async Task<ActionResult> SetupPortfolioMonitoring()
        {
            List<PortfolioMonitoringType> portfolioMonitoringTypes = new();
            try
            {
                var currentUser = await userManager.GetUserAsync(User);
                portfolioMonitoringTypes = await _portfolioModelFactory.PreparePortfolioMonitoringTypesModelAsync(currentUser.Id, null);
            }
            catch (Exception ex)
            {
                _notificatonService.LogErrorWithNotificationAsync(ex);
            }
            return View(portfolioMonitoringTypes);
        }


        [HttpGet]
        public async Task<IActionResult> GetPortfolioCard(string searchKey)
        {
            List<PortfolioMonitoringType> portfolioMonitoringTypes = new();
            try
            {
                var currentUser = await userManager.GetUserAsync(User);
                portfolioMonitoringTypes = await _portfolioModelFactory.PreparePortfolioMonitoringTypesModelAsync(currentUser.Id, null, searchKey);
            }
            catch (Exception ex)
            {
                _notificatonService.LogErrorWithNotificationAsync(ex);
            }
            return Content(await RenderPartialViewToStringAsync("_PortfolioCards", portfolioMonitoringTypes));      
        }

        [HttpGet]
        public async Task<IActionResult> SendEmailVerificationLink(string id)
        {
            string decryptUserId = EncryptHelper.Decrypt(id, Common.EncryptionKey.ToString());
            var user = await userManager.FindByIdAsync(decryptUserId);
            var callbackUrl = Url.RouteUrl("RegisterAccount", new { userId = id }, protocol: HttpContext.Request.Scheme);
            Common.SendEmail(user.Email, "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>", "Confirm your account");
            return RedirectToRoute("SignupConfirmation", new { email = user.Email });
        }

        // GET: /Account/ForgotPassword
        //[AllowAnonymous]
        [HttpGet]
        public ActionResult ForgotPassword()
        {
            ForgotPasswordViewModel forgotPasswordViewModel = new ForgotPasswordViewModel();
            return View(forgotPasswordViewModel);
        }

        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await userManager.FindByNameAsync(model.Email);
                    if (user == null)
                    {
                        ModelState.AddModelError("Email", "Invalid Email");
                        return View(model);
                    }
                    if (!(await userManager.IsEmailConfirmedAsync(user)))
                    {
                        VerifyEmailModel verifyEmailModel = new VerifyEmailModel();
                        verifyEmailModel.UserId = EncryptHelper.Encrypt(user.Id.ToString(), Common.EncryptionKey.ToString());
                        return View("EmailNotConfirmed", verifyEmailModel);
                    }
                    string code = await userManager.GeneratePasswordResetTokenAsync(user);
                    DateTime expiryTime = DateTime.Now.AddMinutes(Convert.ToInt32(Common.LinkExpiryTime));
                    string encryptedKey = Convert.ToString(Common.EncryptionKey);
                    var encryptExpiryTime = EncryptHelper.Encrypt(expiryTime.ToString(), encryptedKey);
                    string parameters = user.Id.ToString() + "&" + code.ToString() + "&" + expiryTime.ToString();
                    string EncryptedParameters = EncryptHelper.Encrypt(parameters, Common.EncryptionKey.ToString());
                    var callbackUrl = Url.RouteUrl("ResetPassword", new { p = EncryptedParameters }, protocol: HttpContext.Request.Scheme);
                    Common.SendEmail(model.Email, "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>", "Reset Password");
                    return RedirectToRoute("ForgotPasswordConfirmation");
                }
                catch (Exception ex)
                {
                    _notificatonService.LogErrorWithNotificationAsync(ex);
                    return RedirectToRoute("ForgotPassword");
                }
            }
            return View(model);
        }

        // GET: /Account/ForgotPasswordConfirmation
        // [AllowAnonymous]
        [HttpGet]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        // GET: /Account/ResetPassword
        // [AllowAnonymous]
        [HttpGet]
        public ActionResult ResetPassword(string p)
        {
            try
            {
                string code = string.Empty;
                string userId = string.Empty;
                string t = string.Empty;
                if (string.IsNullOrEmpty(p))
                {
                    return View("Error");
                }
                else
                {
                    string DecryptedParameters = EncryptHelper.Decrypt(p, Common.EncryptionKey.ToString());
                    if (string.IsNullOrEmpty(DecryptedParameters))
                    {
                        return View("Error");
                    }
                    else
                    {
                        var values = DecryptedParameters.Split("&");
                        if (values.Any())
                        {
                            userId = values[0];
                            code = values[1];
                            t = values[2];
                        }
                        else
                        {
                            return View("Error");
                        }
                    }
                }
                if (string.IsNullOrEmpty(code) || string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(t))
                {
                    return View("Error");
                }
                else
                {
                    DateTime linkExpiryTime = Convert.ToDateTime(t);
                    if (linkExpiryTime > DateTime.Now)
                    {
                        var user = userManager.FindByIdAsync(userId).Result;
                        ResetPasswordViewModel resetPasswordViewModel = new ResetPasswordViewModel();
                        resetPasswordViewModel.Code = code;
                        resetPasswordViewModel.Email = user.Email;
                        return View(resetPasswordViewModel);
                    }
                    else
                    {
                        return RedirectToRoute("LinkExpiryTime");
                    }
                }
            }
            catch (Exception ex)
            {
                _notificatonService.LogErrorWithNotificationAsync(ex);
                return View("Error");
            }
        }

        //
        // POST: /Account/ResetPassword
        [HttpPost]
        //[AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                var user = await userManager.FindByNameAsync(model.Email);
                if (user == null)
                {
                    return RedirectToRoute("ResetPasswordConfirmation");
                }
                var result = await userManager.ResetPasswordAsync(user, model.Code, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToRoute("ResetPasswordConfirmation");
                }
                AddErrors(result);
            }
            catch (Exception ex)
            {
                _notificatonService.LogErrorWithNotificationAsync(ex);
            }
            return View();
        }

        //
        // GET: /Account/ResetPasswordConfirmation
        //[AllowAnonymous]
        [HttpGet]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        //[AllowAnonymous]
        [HttpGet]
        public ActionResult LinkExpiryTime()
        {
            return View();
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }

        protected virtual async Task<string> RenderPartialViewToStringAsync(string viewName, object model)
        {
            
            //create action context
            var actionContext = new ActionContext(HttpContext, RouteData, ControllerContext.ActionDescriptor, ModelState);

            //set view name as action name in case if not passed
            if (string.IsNullOrEmpty(viewName))
                viewName = ControllerContext.ActionDescriptor.ActionName;

            //set model
            ViewData.Model = model;

            //try to get a view by the name
            var viewResult = _razorViewEngine.FindView(actionContext, viewName, false);
            if (viewResult.View == null)
            {
                //or try to get a view by the path
                viewResult = _razorViewEngine.GetView(null, viewName, false);
                if (viewResult.View == null)
                    throw new ArgumentNullException($"{viewName} view was not found");
            }
            await using var stringWriter = new StringWriter();
            var viewContext = new ViewContext(actionContext, viewResult.View, ViewData, TempData, stringWriter, new HtmlHelperOptions());

            await viewResult.View.RenderAsync(viewContext);
            return stringWriter.GetStringBuilder().ToString();
        }
    }
}
