using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

using Orderly.Factories.Token;
using Orderly.Helpers;
using Orderly.Models.Enums;
using Orderly.Models.Portfolio;
using Orderly.Models.Tokens;
using Orderly.Models.ViewModels;
using Orderly.Services.Comman;
using Orderly.Services.Notification;
using Orderly.Services.Portfolio;
using Orderly.Services.Token;
using Orderly.Services.User;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using static Orderly.Helpers.Common;

namespace Orderly.Controllers
{
    [Authorize]
    public class TokenManagementController : Controller
    {
        #region Properties
        private readonly ITokenModelFactory _tokenModelFactory;
        private readonly INotificationService _notificatonService;
        private readonly INetworkTokenService _networkTokenService;
        private readonly ServiceResolver<IPortfolioService> _serviceResolver;
        private readonly ICommanService _commanService;
        private readonly IApplicationUser _appUser;
        #endregion

        #region Constructor
        public TokenManagementController(
            ITokenModelFactory tokenModelFactory,
            INotificationService notificatonService,
            INetworkTokenService networkTokenService,
            ServiceResolver<IPortfolioService> serviceResolver,
            ICommanService commanService,
            IApplicationUser appUser)
        {
            _tokenModelFactory = tokenModelFactory;
            _notificatonService = notificatonService;
            _networkTokenService = networkTokenService;
            _serviceResolver = serviceResolver;
            _commanService = commanService;
            _appUser = appUser;
        }
        #endregion

        [HttpGet]
        public async Task<IActionResult> Index(int id = 0)
        {
            var userId = (await _appUser.GetCurrentUserAsync()).Id;
            var model = await _tokenModelFactory.PrepareTokenManagementModelAsync(userId, id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(TokenManagementModel tokenManagementModel)
        {
            bool success = true;
            try
            {
                var userId = (await _appUser.GetCurrentUserAsync()).Id;
                tokenManagementModel.UserId = userId;
                var apiKey = _commanService.GetApiByKey(tokenManagementModel.NetworkId, true);
                var portfolioService = _serviceResolver(tokenManagementModel.NetworkId.ToString());
                var result = await portfolioService.ValidateContractAsync(tokenManagementModel.Address, apiKey);
                var resultModel = new ValidateContractResultModel();
                if (result != null)
                {
                    resultModel = JsonConvert.DeserializeObject<ValidateContractResultModel>(result);
                    if (resultModel.status == RequestStatus.OK)
                    {
                        List<ContractResultModel> contractResult = (List<ContractResultModel>)resultModel.result;

                        if (string.IsNullOrEmpty(contractResult.FirstOrDefault().SourceCode)
                            || contractResult.FirstOrDefault().ABI.Contains("not verified"))
                        {
                            ModelState.AddModelError(string.Empty, StringResources.ContractTokenNotValid);
                            var model = await _tokenModelFactory.PrepareTokenManagementModelAsync(userId, tokenManagementModel.Id);
                            tokenManagementModel.AvailableNetworks = model.AvailableNetworks;
                            _notificatonService.ErrorNotification(StringResources.ContractTokenNotValid);
                            success = false;
                        }
                        else
                        {
                            success = true;

                            var tokenInfo = await portfolioService.GetTokenInfo(apiKey, tokenManagementModel.Address);
                            var tokenResult = JsonConvert.DeserializeObject<TokenInfoResponseViewModel>(tokenInfo);
                            if (tokenResult.status.ToString() == Convert.ToInt32(RequestStatus.OK).ToString())
                            {
                                var token = JsonConvert.DeserializeObject<List<TokenResult>>(tokenResult.result.ToString()).FirstOrDefault();
                                if (token != null)
                                {
                                    tokenManagementModel.Symbol = token.symbol;
                                }
                            }
                            await _networkTokenService.InsertOrUpdate(tokenManagementModel);
                            _notificatonService.SuccessNotification(StringResources.AddedSucessMessage);
                        }
                    }
                    else
                    {
                        _notificatonService.ErrorNotification(Convert.ToString(resultModel.result));
                    }
                }
            }
            catch (Exception ex)
            {
                success = false;
                _notificatonService.LogErrorWithNotificationAsync(ex);
            }
            return Json(new { success = success });
        }

        public async Task<IActionResult> GetTokens(TokenSearchModel searchModel)
        {
            var model = await _tokenModelFactory.PrepareTokenListModelAsync(searchModel);
            return Json(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            bool isSuccess = true;
            try
            {
                await _networkTokenService.Delete(id);
                _notificatonService.SuccessNotification(StringResources.DeleteMessage);
            }
            catch (Exception ex)
            {
                _notificatonService.LogErrorWithNotificationAsync(ex);
                isSuccess = false;
            }
            return Json(new { success = isSuccess });
        }
    }
}
