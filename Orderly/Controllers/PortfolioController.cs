using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

using Orderly.ActionFilter;
using Orderly.Factories.Portfolio;
using Orderly.Helpers;
using Orderly.Models.Enums;
using Orderly.Models.Portfolio;
using Orderly.Services.Notification;
using Orderly.Services.Portfolio;
using Orderly.Services.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Orderly.Helpers.Common;


namespace Orderly.Controllers
{
    [Authorize]
    [TypeFilter(typeof(HandleErrorCustomAttribute))]
    public class PortfolioController : Controller
    {
        #region Properties
        private readonly IPortfolioMonitoringService _portfolioMonitoringService;
        private readonly IPortfolioModelFactory _portfolioModelFactory;
        private readonly ServiceResolver<IPortfolioService> _serviceResolver;
        private readonly IApplicationUser _appUser;
        private readonly IConfiguration _configuration;
        private readonly INotificationService _notificatonService;
        #endregion

        #region  Constructor
        public PortfolioController(IPortfolioMonitoringService portfolioMonitoringService,
            ServiceResolver<IPortfolioService> serviceResolver,
            IPortfolioModelFactory portfolioModelFactory,
            IApplicationUser appUser,
            IConfiguration configuration,
            INotificationService notificatonService
           )
        {
            _portfolioMonitoringService = portfolioMonitoringService;
            _serviceResolver = serviceResolver;
            _portfolioModelFactory = portfolioModelFactory;
            _appUser = appUser;
            _configuration = configuration;
            _notificatonService = notificatonService;
        }
        #endregion

        #region Methods
        // GET: Validation
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> ValidateAddress(string address, int type)
        {
            try
            {
                var portfolioService = _serviceResolver(type.ToString());
                //calling api to validate address async
                var result = await portfolioService.ValidateAddressAsync(address, GetApiKey(type));
                var model = JsonConvert.DeserializeObject<AddressValidationResultModel>(result);
                return Json(model);
            }
            catch (Exception ex)
            {
                _notificatonService.LogErrorWithNotificationAsync(ex);
                return Json(new AddressValidationResultModel { status = 0, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult> SavePortfolioMonitoring(List<PortFolioMonitoringModel> portFolios)
        {
            try
            {
                var notInserted = new List<string>();
                foreach (var item in portFolios.ToList())
                {
                    var portfolioService = _serviceResolver(item.TypeId.ToString());
                    //calling api to validate address async
                    var result = await portfolioService.ValidateAddressAsync(item.Address, GetApiKey(item.TypeId));
                    var model = JsonConvert.DeserializeObject<AddressValidationResultModel>(result);
                    //Check and Remove Invalid Address from List
                    if (model.status.ToString().ToLower() == RequestStatus.NOTOK.ToString().ToLower())
                    {
                        notInserted.Add(item.Address);
                        portFolios.Remove(item);
                    }
                }
                if (notInserted.Count <= 0)
                {
                    var _currentUser = await _appUser.GetCurrentUserAsync();
                    portFolios.ForEach(x => x.UserId = _currentUser.Id);
                    await _portfolioMonitoringService.AddOrUpdateAddressToTableAsync(portFolios);
                    _notificatonService.SuccessNotification(StringResources.AddedSucessMessage);
                }
                else
                {
                    foreach (var address in notInserted)
                        _notificatonService.ErrorNotification(string.Format(StringResources.NotVerifiedAddress, address));
                }
                return Json(new
                {
                    status = notInserted.Count <= 0,
                    notInserted = notInserted,
                    message = StringResources.AddedSucessMessage
                });
            }
            catch (Exception ex)
            {
                _notificatonService.LogErrorWithNotificationAsync(ex);
                return Json(new
                {
                    status = false,
                    message = ex.Message
                });
            }
        }

        public async Task<ActionResult> DeletePortfolioMonitoring(int addressId)
        {
            try
            {
                var _currentUser = await _appUser.GetCurrentUserAsync();
                await _portfolioMonitoringService.DeleteAddressToTableAsync(addressId, _currentUser.Id);
                _notificatonService.SuccessNotification(StringResources.DeleteMessage);
                return Json(new
                {
                    status = true,
                    message = StringResources.DeleteMessage
                });
            }
            catch (Exception ex)
            {
                _notificatonService.LogErrorWithNotificationAsync(ex);
                return Json(new
                {
                    status = false,
                    message = ex.Message
                });
            }
        }

        [HttpGet]
        public async Task<ActionResult> ShowAddressPopup(int typeId)
        {
            var _currentUser = await _appUser.GetCurrentUserAsync();
            var model = await _portfolioModelFactory.PreparePortfolioMonitoringTypesModelAsync(_currentUser.Id, typeId);
            return PartialView("_AddressModelPopup", model);
        }
        #endregion

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
                case (int)ApiKeyType.EthPlorer:
                    apiKey = Convert.ToString(apiConfigSection["apiKeyEthPlorer"]);
                    break;
                case (int)ApiKeyType.CryptoCompare:
                    apiKey = Convert.ToString(apiConfigSection["apiKeyCryptoCompare"]);
                    break;
            }
            return apiKey;
        }
        #endregion
    }
}
