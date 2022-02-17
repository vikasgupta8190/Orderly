using Microsoft.AspNetCore.Mvc.Rendering;

using Orderly.Models.Comman;
using Orderly.Models.Enums;
using Orderly.Models.Extensions;
using Orderly.Models.OTC;
using Orderly.Services.OverTheCounter;
using Orderly.Services.Token;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orderly.Factories.OverTheCounter
{
    public class OTCModelFactory : IOTCModelFactory
    {
        #region Properties
        private readonly IOTCService _otcService;
        private readonly INetworkTokenService _tokenService;
        #endregion

        #region Constructor
        public OTCModelFactory(
            IOTCService otcService,
            INetworkTokenService tokenService
            )
        {
            _otcService = otcService;
            _tokenService = tokenService;
        }

        public async Task<OTCListModel> PrepareOTCListModel(int userId, OTCSearchModel searchModel)
        {
            var list = await _otcService.GetAll(userId, searchModel.Page - 1, searchModel.PageSize);
            return new OTCListModel().PrepareToGrid(searchModel, list, () =>
            {
                return list.Select(x =>
                {
                    return new OTCModel()
                    {
                        Id = x.Id,
                        ContactDetails = x.ContactDetails,
                        Currency = x.Currency,
                        Email = x.Email,
                        Lockup = x.Lockup,
                        PricePerToken = x.PricePerToken,
                        TelegramUsername = x.TelegramUsername,
                        TokenQty = x.TokenQty,
                        TotalAmount = x.TotalAmount,
                        Vesting = x.Vesting,
                        TokenId = x.TokenId,
                        Type = x.Type,
                        TokenName = x.networkTokens.Name,
                        TokenAddress = x.networkTokens.Address,
                        NetworkUrl = GetNetworkUrl(x.networkTokens.NetworkId)
                    };
                });
            });
        }
        #endregion

        #region Methods

        public async Task<OTCModel> PrepareOTCModel(int userId, int Id = 0)
        {
            OTCModel oTCModel = new OTCModel();

            List<SelectListItem> typeList = new List<SelectListItem>();
            typeList.Add(new SelectListItem { Text = "Buy", Value = "buy" });
            typeList.Add(new SelectListItem { Text = "Sell", Value = "sell" });
            oTCModel.TypeList = typeList;

            var tokenIds = await _otcService.GetAssignedTokenIds(userId);
            var tokenList = (await _tokenService.GetAll()).Where(x => x.UserId == userId);

            if(Id == 0)
            {
                tokenList = tokenList.Where(x=> !tokenIds.Contains(x.Id)).ToList();
            }
           
            oTCModel.TokenList = tokenList.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
            if (Id > 0)
            {
                var otc = await _otcService.GetById(Id);
                oTCModel.Id = otc.Id;
                oTCModel.Lockup = otc.Id;
                oTCModel.PricePerToken = otc.PricePerToken;
                oTCModel.TelegramUsername = otc.TelegramUsername;
                oTCModel.TokenId = otc.TokenId;
                oTCModel.TokenQty = otc.TokenQty;
                oTCModel.TotalAmount = otc.TotalAmount;
                oTCModel.Type = otc.Type;
                oTCModel.Vesting = otc.Vesting;
                oTCModel.ContactDetails = otc.ContactDetails;
                oTCModel.Currency = otc.Currency;
                oTCModel.Email = otc.Email;
            }
            return oTCModel;
        }

        private string GetNetworkUrl(int networkId)
        {
            string url = string.Empty;
            switch (networkId)
            {
                case (int)PortfolioMonitoringTypes.Etherum:
                    url = "https://etherscan.io/token/";
                    break;
                case (int)PortfolioMonitoringTypes.BitCoin:
                    url = "https://bscscan.com/token/";
                    break;
                default:
                    break;
            }
            return url;
        }
        #endregion
    }
}
