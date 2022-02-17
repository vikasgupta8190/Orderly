using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Orderly.Core.Domain.Common;
using Orderly.Core.Domain.Contact;
using Orderly.Core.Domain.Portfolio;
using Orderly.Core.Domain.Tokens;
using Orderly.Models.Comman;
using Orderly.Models.Enums;
using Orderly.Models.Monitor;
using Orderly.Models.Tokens;
using Orderly.Models.ViewModels;
using Orderly.Repositories;
using Orderly.Services.Comman;
using Orderly.Services.Email;
using Orderly.Services.Investment;
using Orderly.Services.Portfolio;
using Orderly.Services.Token;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Orderly.Helpers.Common;

namespace Orderly.Services.Monitor
{
    public class MonitoringService : IMonitoringService
    {
        #region Properties
        private readonly IRepository<Monitoring> _monitoringRepository;
        private readonly IRepository<PortfolioMonitoring> _portfolioMonitoringrepository;
        private readonly ICommanService _commanService;
        private readonly ServiceResolver<IPortfolioService> _serviceResolver;
        private readonly INetworkTokenService _tokenService;
        private readonly IQueuedEmailService _emailService;
        private readonly IInvestmentService _investmentService;
        #endregion

        #region constructor
        public MonitoringService(IRepository<Monitoring> monitoringRepository,
            IRepository<PortfolioMonitoring> portfolioMonitoringrepository,
            ICommanService commanService,
            ServiceResolver<IPortfolioService> serviceResolver,
            INetworkTokenService tokenService,
            IQueuedEmailService emailService,
            IInvestmentService investmentService)
        {
            _monitoringRepository = monitoringRepository;
            _portfolioMonitoringrepository = portfolioMonitoringrepository;
            _commanService = commanService;
            _serviceResolver = serviceResolver;
            _tokenService = tokenService;
            _emailService = emailService;
            _investmentService = investmentService;
        }
        #endregion

        #region Methods
        public async Task DeleteAsync(int id)
        {
            var monitor = await GetMonitoringByIdAsync(id);
            if (monitor != null)
                await _monitoringRepository.DeleteAsync(monitor);
        }

        public async Task DeleteByNetworkIdAsync(int networkId, int userId)
        {
            var monitorings = await GetMonitoringsByNetworkIdAsync(networkId, userId);
            monitorings.ForEach(x => x.PortfolioMonitoring = null);
            if (monitorings.Any())
            {
                await _monitoringRepository.DeleteAllAsync(monitorings);
            }
        }

        public async Task<List<Monitoring>> GetAllMonitoringAsync(int customerId)
        {
            return await (await _monitoringRepository.GetAllAsync(x => x.UserId == customerId))
                .Include(x => x.PortfolioMonitoring)
                .ThenInclude(x => x.User)
                .Include(x => x.PortfolioMonitoring)
                .ThenInclude(x => x.MonitoringType)
               .ToListAsync();
        }

        public async Task<Monitoring> GetMonitoringByIdAsync(int id)
        {
            return await _monitoringRepository.GetByIdAsync(id);
        }

        public async Task<IPagedList<Monitoring>> GetMonitoringPagedListByNetworkIdAsync(int id, int userId, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            return await (await GetMonitoringsByNetworkIdAsync(id, userId)).AsQueryable().ToPagedListAsync(pageIndex, pageSize);
        }

        public async Task<List<Monitoring>> GetMonitoringsByNetworkIdAsync(int id, int userId)
        {
            return (await _monitoringRepository.GetAllAsync(x => x.PortfolioMonitoring.MonitoringType.Id == id && x.UserId == userId))
                .Include(x => x.PortfolioMonitoring)
                .ThenInclude(x => x.MonitoringType)
               .ToList();

        }

        public async Task InsertOrUpdateAsync(MonitoringModel model, int userId)
        {
            if (model.Id <= 0)
            {
                foreach (var montior in model.AddressIds)
                {
                    await _monitoringRepository.InsertAsync(new Monitoring()
                    {
                        UserId = userId,
                        ShowInPortfolio = model.ShowInPortfolio,
                        IncommingTokenNotificationEvent = model.IncommingTokenNotificationEvent,
                        PortfolioMonitoringId = montior,
                        TokenGenerationNotificationEvent = model.TokenGenerationNotificationEvent
                    });
                }
            }
            else
            {
                var monitor = await GetMonitoringByIdAsync(model.Id);
                monitor.IncommingTokenNotificationEvent = model.IncommingTokenNotificationEvent;
                monitor.ShowInPortfolio = model.ShowInPortfolio;
                monitor.TokenGenerationNotificationEvent = model.TokenGenerationNotificationEvent;

                await _monitoringRepository.UpdateAsync(monitor);
            }
        }

        public async Task MonitorAddress()
        {
            try
            {
                var monitors = await (await _monitoringRepository.GetAllAsync())
                    .Include(x => x.PortfolioMonitoring).ThenInclude(x => x.MonitoringType)
                    .Include(x => x.PortfolioMonitoring).ThenInclude(x => x.User)
                    .ToListAsync();

                if (monitors != null)
                {
                    foreach (var monitor in monitors)
                    {
                        var address = monitor.PortfolioMonitoring.Address;
                        var networkId = monitor.PortfolioMonitoring.MonitoringType.Id;
                        var user = monitor.PortfolioMonitoring.User;
                        if (monitor.IncommingTokenNotificationEvent)
                        {
                            var apiKey = _commanService.GetApiByKey(networkId);
                            var portfolioService = _serviceResolver(networkId.ToString());
                            var transactions = await portfolioService.GetTransactionListByUserAddress(address, apiKey, DateTime.UtcNow.Date, DateTime.UtcNow.Date);
                            var transactionsResult = JsonConvert.DeserializeObject<TransactionResponseViewModel>(transactions);
                            if (transactionsResult.status.ToString() == Convert.ToInt32(RequestStatus.OK).ToString())
                            {
                                var result = transactionsResult.result;
                                if (result.Count > 0)
                                {
                                    var contractAddresses = result.Where(x => !string.IsNullOrEmpty(x.contractAddress)).Select(x => x.contractAddress).ToList();
                                    foreach (var contractAddress in contractAddresses)
                                    {
                                        await AddToken(contractAddress, networkId, user, address);
                                    }
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

        private async Task AddToken(string contractAddress, int networkId, ApplicationUser user, string address)
        {
            string emailSubject = "New Token Generated";
            NetworkToken networkToken = await _tokenService.GetByAddress(contractAddress);
            if (networkToken == null)
            {
                var apiKey = _commanService.GetApiByKey(networkId, true);
                var portfolioService = _serviceResolver(networkId.ToString());
                var tokenInfo = await portfolioService.GetTokenInfo(apiKey, contractAddress);
                var tokenResult = JsonConvert.DeserializeObject<TokenInfoResponseViewModel>(tokenInfo);
                if (tokenResult.status.ToString() == Convert.ToInt32(RequestStatus.OK).ToString())
                {
                    TokenManagementModel tokenManagementModel = new TokenManagementModel();
                    var token = JsonConvert.DeserializeObject<List<TokenResult>>(tokenResult.result.ToString()).FirstOrDefault();
                    var tokenPrice = Convert.ToDecimal(token.tokenPriceUSD);
                    tokenManagementModel.Name = token.tokenName;
                    tokenManagementModel.Address = contractAddress;
                    tokenManagementModel.NetworkId = networkId;
                    tokenManagementModel.UserId = user.Id;
                    tokenManagementModel.CurrentPriceUSD = tokenPrice;
                    tokenManagementModel.AllTimeHighValue = tokenPrice;
                    tokenManagementModel.AllTimeLowValue = tokenPrice;
                    tokenManagementModel.Symbol = token.symbol;
                    await _tokenService.InsertOrUpdate(tokenManagementModel);
                    /// add mail entry to table
                    string body = TGEEmailBody(user.UserName, tokenManagementModel.Name, address, tokenManagementModel.Id);
                    await _emailService.Insert(user.Email, emailSubject, null, body, 1, null, token.contractAddress, true);
                }
            }
            else
            {
                /// if token is not associate with any investment then add to queued email table
                if (!await isTokenAssociated(networkToken.Id))
                {
                    string body = TGEEmailBody(user.UserName, networkToken.Name, address, networkToken.Id);
                    await _emailService.Insert(user.Email, emailSubject, null, body, Convert.ToInt32(EmailPriority.High), null, networkToken.Address, true);
                }
            }
        }

        private string TGEEmailBody(string userName, string tokenName, string address,int tokenId)
        {
            var callbackUrl = WebsiteUrl + "edit-token?Id=" + tokenId;
            string body = "Hi " + userName + ", </br></br>" + "New " + tokenName + " token is generated corresponding to this address " + address + ". ";
            body += "Please click <a href=\"" + callbackUrl + "\">here</a> to associate the token with investment";
            return body;
        }

        private async Task<bool> isTokenAssociated(int tokenId)
        {
            return await _investmentService.isTokenAssociated(tokenId);
        }

        public async Task UpdateAllNetworkNotificationAsync(int networkId, int userId, bool enable)
        {
            var monitors = await GetMonitoringsByNetworkIdAsync(networkId, userId);
            if (monitors.Any())
            {
                monitors.ForEach(x => x.IncommingTokenNotificationEvent = enable);
                monitors.ForEach(x => x.TokenGenerationNotificationEvent = enable);
                monitors.ForEach(x => x.PortfolioMonitoring = null);
                await _monitoringRepository.UpdateAllAsync(monitors);
            }
        }

        public async Task UpdateAllNetworkShowOnPortfolioAsync(int networkId, int userId, bool enable)
        {
            var monitors = await GetMonitoringsByNetworkIdAsync(networkId, userId);
            if (monitors.Any())
            {
                monitors.ForEach(x => x.ShowInPortfolio = enable);
                monitors.ForEach(x => x.PortfolioMonitoring = null);
                await _monitoringRepository.UpdateAllAsync(monitors);
            }
        }

        public async Task UpdateTokenNotificationAsync(int monitoringId, int userId, bool enable)
        {
            var monitoring = await GetMonitoringByIdAsync(monitoringId);
            if (monitoring != null)
            {
                monitoring.IncommingTokenNotificationEvent = enable;
                await _monitoringRepository.UpdateAsync(monitoring);
            }
        }
        public async Task UpdateTokenGenerationAsync(int monitoringId, int userId, bool enable)
        {
            var monitoring = await GetMonitoringByIdAsync(monitoringId);
            if (monitoring != null)
            {
                monitoring.TokenGenerationNotificationEvent = enable;
                await _monitoringRepository.UpdateAsync(monitoring);
            }
        }
        #endregion
    }
}
