using Microsoft.AspNetCore.Mvc.Rendering;

using Orderly.Core.Domain.Tokens;
using Orderly.Models.Extensions;
using Orderly.Models.Investment;
using Orderly.Models.Tokens;
using Orderly.Repositories;
using Orderly.Services.Investment;
using Orderly.Services.Portfolio;
using Orderly.Services.Token;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orderly.Factories.Token
{
    public class TokenModelFactory : ITokenModelFactory
    {
        #region Properties
        private readonly INetworkTokenService _tokenService;
        private readonly IPortfolioMonitoringService _portfolioMonitoringService;
        private readonly IInvestmentService _investmentService;
        #endregion

        #region Constructor
        public TokenModelFactory(INetworkTokenService tokenService,
            IPortfolioMonitoringService portfolioMonitoringService,
            IInvestmentService investmentService)
        {
            _tokenService = tokenService;
            _portfolioMonitoringService = portfolioMonitoringService;
            _investmentService = investmentService;
        }

        #endregion
        public async Task<TokenListModel> PrepareTokenListModelAsync(TokenSearchModel searchModel)
        {
            var tokenList = await _tokenService.GetAllTokensPagedListByNetworkId(searchModel.Page - 1, searchModel.PageSize);
            //prepare list model
            return new TokenListModel().PrepareToGrid(searchModel, tokenList, () =>
            {
                return tokenList.Select(token =>
                {
                    return new TokenModel()
                    {
                        Address = token.Address,
                        Name = token.Name,
                        NetworkName = token.Network.Type,
                        Id = token.Id
                    };
                });
            });
        }

        public async Task<TokenManagementModel> PrepareTokenManagementModelAsync(int userId, int id = 0)
        {
            TokenManagementModel tokenManagementModel = new();
            var availableNetwork = (await _portfolioMonitoringService.GetAllMonitoringTypesAsync()).Select(x => new SelectListItem()
            {
                Text = x.Type,
                Value = x.Id.ToString()
            }).ToList();

            var availableInvestment = (await _investmentService.GetInvestmentsByUserIdAndTokenAsync(userId, id)).Select(x => new SelectListItem()
            {
                Text = x.InvestmentTransactionLink.ToString(),
                Value = x.Id.ToString()
            }).ToList();

            if (id > 0)
            {
                var token = await _tokenService.GetById(id);
                if (token != null)
                {
                    tokenManagementModel = new TokenManagementModel
                    {
                        Id = token.Id,
                        Address = token.Address,
                        Name = token.Name,
                        NetworkId = token.NetworkId,
                        AvailableNetworks = availableNetwork,
                        AvailableInvestment = availableInvestment,
                        InvestmentId = token.userInvestment.FirstOrDefault()?.Id
                    };
                }
            }
            else
            {
                tokenManagementModel.AvailableNetworks = availableNetwork;
                tokenManagementModel.AvailableInvestment = availableInvestment;
            }
            return tokenManagementModel;
        }
    }
}
