using Orderly.Core.Domain.Investment;
using Orderly.Models.Comman;
using Orderly.Models.Dashboard;
using Orderly.Models.Enums;
using Orderly.Models.Extensions;
using Orderly.Services.Investment;
using Orderly.Services.Token;
using Orderly.Services.User;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orderly.Factories.Dashboard
{
    public class DashboardModelFactory : IDashboardModelFactory
    {
        private readonly ICalendarService _calendarService;
        private readonly IApplicationUser _appUser;
        private readonly INetworkTokenService _networkTokenService;
        private readonly IInvestmentService _investmentService;

        public DashboardModelFactory(ICalendarService calendarService,
            IApplicationUser appUser,
            INetworkTokenService networkTokenService,
            IInvestmentService investmentService)
        {
            _calendarService = calendarService;
            _appUser = appUser;
            _networkTokenService = networkTokenService;
            _investmentService = investmentService;
        }

        public async Task<List<PieChartModel>> PreparePieChartModelData(int userId, List<int> networkIds)
        {
            var userInvestments = await _investmentService.GetInvestmentsByUserIdAndNetworkIds(userId, networkIds);
            var groupedInvestments = userInvestments.GroupBy(x => x.MonitoringTypeId)
                .Select(x=> new PieChartModel { 
                Token = x.FirstOrDefault().MonitoringType?.Type,
                AmountInvested = x.Sum(y => y.InvestedAmount)
                })
                .ToList();
            return groupedInvestments;
        }

        public async Task<TokenListModel> PrepareTokenListModelAsync(TokenSearchModel searchModel, bool isUpcoming)
        {
            var tokenListModel = await _calendarService.GetCalendarsTokens((await _appUser.GetCurrentUserAsync()).Id, isUpcoming,searchModel.NetworkId, searchModel.NextDays, searchModel.PrevDays, searchModel.PageSize, searchModel.Page - 1);
            //prepare list model
            return new TokenListModel().PrepareToGrid(searchModel, tokenListModel, () =>
            {
                return tokenListModel.Select(x =>
                {
                    return x;
                });
            });
        }

        public async Task<TokenOverviewListModel> PrepareTokenOverviewListModel(TokenSearchModel searchModel)
        {
            var tokenListModel = await _networkTokenService.GetTokenOverview((await _appUser.GetCurrentUserAsync()).Id, searchModel.NetworkId, searchModel.Page - 1, searchModel.PageSize);
            //prepare list model
            return new TokenOverviewListModel().PrepareToGrid(searchModel, tokenListModel, () =>
            {
                return tokenListModel.Select(x =>
                {
                    return x;
                });
            });
        }
    }
}
