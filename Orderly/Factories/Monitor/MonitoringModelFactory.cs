using Microsoft.AspNetCore.Mvc.Rendering;
using Orderly.Models.Extensions;
using Orderly.Models.Monitor;
using Orderly.Services.Monitor;
using Orderly.Services.Portfolio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orderly.Factories.Monitor
{
    public class MonitoringModelFactory : IMonitoringModelFactory
    {
        #region Properties
        private readonly IMonitoringService _monitoringService;
        private readonly IPortfolioMonitoringService _portfolioMonitoringService;
        #endregion

        #region Constructor
        public MonitoringModelFactory(IMonitoringService monitoringService,
            IPortfolioMonitoringService portfolioMonitoringService)
        {
            _monitoringService = monitoringService;
            _portfolioMonitoringService = portfolioMonitoringService;
        }
        #endregion
        public async Task<MonitoringListModel> PrepareMonitoringListModelAsync(int networkId, int userId, MonitoringSearchModel searchModel)
        {
            var monitor = await _monitoringService.GetMonitoringPagedListByNetworkIdAsync(networkId, userId, searchModel.Page - 1, searchModel.PageSize);
            //prepare list model
            var model = new MonitoringListModel().PrepareToGrid(searchModel, monitor, () =>
             {
                 return monitor.Select(x =>
                 {
                     return new MonitoringModel()
                     {
                         Addresses = x.PortfolioMonitoring.Address,
                         Id = x.Id,
                         IncommingTokenNotificationEvent = x.IncommingTokenNotificationEvent,
                         Token = string.Empty,
                         TokenGenerationNotificationEvent = x.TokenGenerationNotificationEvent,
                         ShowInPortfolio = x.ShowInPortfolio
                     };
                 });
             });
            model.EnableIncommingTokenNotification = monitor.Any(x => x.IncommingTokenNotificationEvent || x.TokenGenerationNotificationEvent);
            
            model.ShowPortfolio = monitor.Any(x => x.ShowInPortfolio);
            return model;
        }

        public async Task<MonitorModel> PrepareMonitorModelAsync(int userId)
        {
            var model = new MonitorModel();
            model.AvailableAddresses = (await _portfolioMonitoringService.GetAllAddressesByUserIdAsync(userId)).Where(x => x.Monitoring == null).Select(x => new SelectListItem()
            {
                Text = x.Address,
                Value = x.Id.ToString()
            }).ToList();
            return model;
        }
    }
}
