using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

using Orderly.ActionFilter;
using Orderly.Factories.Investment;
using Orderly.Helpers;
using Orderly.Models.Comman;
using Orderly.Models.Enums;
using Orderly.Models.Investment;
using Orderly.Models.Portfolio;
using Orderly.Models.ViewModels;
using Orderly.Services.Contact;
using Orderly.Services.Investment;
using Orderly.Services.Monitor;
using Orderly.Services.Notification;
using Orderly.Services.Portfolio;
using Orderly.Services.User;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;

using static Orderly.Helpers.Common;

namespace Orderly.Controllers
{
    [Authorize]
    [TypeFilter(typeof(HandleErrorCustomAttribute))]
    public class InvestmentController : Controller
    {
        #region Properties
        private readonly IInvestmentModelFactory _investmentModelFactory;
        private readonly IApplicationUser _appUser;
        private readonly IInvestmentService _investmentService;
        private readonly ServiceResolver<IPortfolioService> _serviceResolver;
        private readonly IConfiguration _configuration;
        private readonly INotificationService _notificatonService;
        private IHostingEnvironment _hostingEnvironment;
        private readonly IContactService _contactService;
        private readonly IMonitoringService _monitoringService;
        #endregion

        #region Constructor
        public InvestmentController(
            IInvestmentModelFactory investmentModelFactory,
            IApplicationUser appUser,
            IInvestmentService investmentService,
            ServiceResolver<IPortfolioService> serviceResolver,
            IConfiguration configuration,
            INotificationService notificatonService,
            IHostingEnvironment hostingEnvironment,
            IContactService contactService,
            IMonitoringService monitoringService)
        {
            _investmentModelFactory = investmentModelFactory;
            _appUser = appUser;
            _investmentService = investmentService;
            _serviceResolver = serviceResolver;
            _configuration = configuration;
            _notificatonService = notificatonService;
            _hostingEnvironment = hostingEnvironment;
            _contactService = contactService;
            _monitoringService = monitoringService;
        }
        #endregion

        /// <summary>
        /// Get Investment List
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var model = await _investmentModelFactory.PrepareUserInvestmentModelAsync((await _appUser.GetCurrentUserAsync()).Id);
            return View(model);
        }

        /// <summary>
        /// Save Investment data
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(UserInvestmentModel model)
        {
            int investmentId = 0;
            try
            {
                string message = StringResources.AddedSucessMessage;
                if (model.Id > 0)
                {
                    message = StringResources.UpdateSuccessMessage;
                }
                List<string> errors = new List<string>();
                if (ModelState.IsValid)
                {
                    investmentId = await _investmentService.InsertOrUpdateInvestmentAsync(model);
                    _notificatonService.SuccessNotification(message);
                }
                else
                {
                    foreach (var modelState in ViewData.ModelState.Values)
                    {
                        foreach (var modelError in modelState.Errors)
                        {
                            errors.Add(modelError.ErrorMessage);
                        }
                    }
                }
                return Json(new
                {
                    id= investmentId,
                    success = errors.Count < 1,
                    error = errors
                });
            }
            catch (Exception ex)
            {
                _notificatonService.LogErrorWithNotificationAsync(ex);
                return Json(new
                {
                    id = investmentId,
                    success = false,
                    error = new { ex.Message }
                });
            }
        }

        /// <summary>
        /// upload saft file
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<bool> UploadSaftFile(int id)
        {
            bool result = true;
            try
            {
                long size = 0;
                var file = Request.Form.Files;
                var filename = ContentDispositionHeaderValue
                                .Parse(file[0].ContentDisposition)
                                .FileName
                                .Trim('"');
                var name = Path.GetFileNameWithoutExtension(filename);
                string extension = Path.GetExtension(filename);
                string fileUniqueName = name  + "" + string.Format("{0:yyyyMMddHHmmssfff}", DateTime.Now) + extension;

                string folderPath = _hostingEnvironment.WebRootPath + $@"\SaftFiles";
                string FilePath = folderPath + $@"\{ fileUniqueName}";
                size += file[0].Length;
                
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                using (FileStream fs = System.IO.File.Create(FilePath))
                {
                    file[0].CopyTo(fs);
                    fs.Flush();
                }
                await _investmentService.UpdateSaftFile(filename,fileUniqueName, id);
            }
            catch (Exception ex)
            {
                result = false;
                _notificatonService.LogErrorWithNotificationAsync(ex);
            }
            return result;
        }

        /// <summary>
        /// download saft file
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> DownloadSaftFile(int id)
        {
            try
            {
                var userInvestment = await _investmentService.GetById(id);
                string folderPath = _hostingEnvironment.WebRootPath + $@"\SaftFiles";
                string FilePath = folderPath + $@"\{ userInvestment.SaftPathSavedFileName}";
                if (Directory.Exists(folderPath))
                {
                    if (System.IO.File.Exists(FilePath))
                    {
                        byte[] fileBytes = System.IO.File.ReadAllBytes(FilePath);
                        return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, userInvestment.SaftFile);
                    }
                }
                _notificatonService.ErrorNotification(StringResources.FileNotFound);
                return RedirectToAction("Edit", new {id = id });
            }
            catch (Exception ex)
            {
                _notificatonService.LogErrorWithNotificationAsync(ex);
                return Json(new { Message = ex.Message, success = false });
            }
        }

        /// <summary>
        /// get investments
        /// </summary>
        /// <param name="searchModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> GetInvestments(InvestmentSearchModel searchModel)
        {
            var model = await _investmentModelFactory.PrepareInvestmentListModelAsync(searchModel, (await _appUser.GetCurrentUserAsync()).Id);
            return Json(model);
        }

        /// <summary>
        /// add/update refund amount
        /// </summary>
        /// <param name="refundModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddRefund(RefundModel refundModel)
        {
            bool success = true;
            try
            {
                await _investmentService.UpdateRefundAmount(refundModel);
                _notificatonService.SuccessNotification(StringResources.AddedSucessMessage);
            }
            catch (Exception ex)
            {
                _notificatonService.LogErrorWithNotificationAsync(ex);
                success = false;
            }
            return Json(new
            {
                success = success,
            });
        }

        /// <summary>
        /// get invested amount by transaction link
        /// </summary>
        /// <param name="transactionLink"></param>
        /// <param name="networkId"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GetInvestedAmount(string transactionLink, int networkId)
        {
            decimal investedAmount = 0;
            string message = string.Empty;
            decimal investedQty = 0;
            bool isSuccess = true;
            string fromAddress = string.Empty;
            try
            {
                var portfolioService = _serviceResolver(networkId.ToString());

                /// get details
                var transactionDetails = await portfolioService.GetDetailByTransactionLink(transactionLink, GetApiKey(networkId));
                var transactionDetailsResult = JsonConvert.DeserializeObject<TransactionDetailModel>(transactionDetails);

                if(transactionDetailsResult != null)
                {
                    if(transactionDetailsResult.error == null && transactionDetailsResult.result != null)
                    {
                        var value = transactionDetailsResult.result.value;
                        var intValue = Convert.ToInt64(value, 16);
                        fromAddress = transactionDetailsResult.result.from;
                        if (intValue != 0)
                        {
                            investedQty = (Convert.ToDecimal(intValue) / 1000000000000000000);
                            /// get current currency rate
                            var getCurrencyRateResult = await portfolioService.GetCurrencyRate(GetApiKey(networkId));
                            var currencyRate = JsonConvert.DeserializeObject<CurrencyModel>(getCurrencyRateResult);
                            if(currencyRate.result != null)
                            {
                                var etherumValue = Convert.ToDecimal(currencyRate.result.ethusd);
                                investedAmount = Math.Round(etherumValue * investedQty, 2);
                            }
                            else
                            {
                                isSuccess = false;
                                message = StringResources.ErrorMessage;
                            }
                        }
                        else
                        {
                            isSuccess = false;
                            message = StringResources.ErrorMessage;
                        }
                    }
                    else
                    {
                        isSuccess = false;
                        message = StringResources.InvalidTransactionLink;
                    }
                }
                else
                {
                    isSuccess = false;
                    message = StringResources.InvalidTransactionLink;
                }
            }
            catch (Exception ex)
            {
                _notificatonService.LogErrorWithNotificationAsync(ex);
                isSuccess = false;
                message = ex.Message;
            }
            return Json(new
            {
                value = investedAmount,
                message = message,
                success = isSuccess,
                investmentQuantity = investedQty,
                fromAddress = fromAddress
            });
        }

        /// <summary>
        /// update invested data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(int id)
        {
            UserInvestmentModel userInvestment = new();
            try
            {
                var userId = (await _appUser.GetCurrentUserAsync()).Id;
                userInvestment = await _investmentModelFactory.GetByIdAndUserId(id, userId);
            }
            catch (Exception ex)
            {
                _notificatonService.LogErrorWithNotificationAsync(ex);
            }
            return View(userInvestment);
        }

        /// <summary>
        /// delete investment
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(int id)
        {
            bool isSuccess = true;
            try
            {
                await _investmentService.Delete(id);
                _notificatonService.SuccessNotification(StringResources.DeleteMessage);
            }
            catch (Exception ex)
            {
                _notificatonService.LogErrorWithNotificationAsync(ex);
                isSuccess = false;
            }
            return Json(new { success = isSuccess});
        }

        public async Task<IActionResult> GetContactDetailByAddress(string address)
        {
            int id = 0;
            string name = string.Empty;
            bool isSuccess = true;
            try
            {
                var contact = await _contactService.GetByAddress(address);
                if(contact != null)
                {
                    id = contact.Id;
                    name = contact.Name;
                }
                else
                {
                    isSuccess = false;
                    _notificatonService.ErrorNotification(StringResources.ContactNotAvailable);
                    id = -1;
                }
            }
            catch (Exception ex)
            {
                _notificatonService.LogErrorWithNotificationAsync(ex);
                isSuccess = false;
            }
            return Json(new { id = id, name = name, success= isSuccess });
        }

        #region Utilitites
        private string GetApiKey(int type)
        {
            var apiConfigSection = _configuration.GetSection("APIKeys");
            var apiKey = string.Empty;
            switch (type)
            {
                case (int)PortfolioMonitoringTypes.Etherum:
                    apiKey = Convert.ToString(apiConfigSection["apikeyETH"]);
                    break;
                case (int)PortfolioMonitoringTypes.BitCoin:
                    apiKey = Convert.ToString(apiConfigSection["apikeyBTC"]);
                    break;
            }
            return apiKey;
        }
        #endregion
    }
}
