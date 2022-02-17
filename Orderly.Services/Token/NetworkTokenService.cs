using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;

using Orderly.Core.Domain.Investment;
using Orderly.Core.Domain.Tokens;
using Orderly.Models.Comman;
using Orderly.Models.Dashboard;
using Orderly.Models.Enums;
using Orderly.Models.Tokens;
using Orderly.Models.ViewModels;
using Orderly.Repositories;
using Orderly.Services.Comman;
using Orderly.Services.Portfolio;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using static Orderly.Helpers.Common;

namespace Orderly.Services.Token
{
    public class NetworkTokenService : INetworkTokenService
    {
        #region Properties
        private readonly IRepository<NetworkToken> _networkTokenRepository;
        private readonly IRepository<UserInvestment> _userInvestmentRepository;
        private readonly IRepository<Calendar> _calendarRepository;
        private readonly ICommanService _commanService;
        private readonly ServiceResolver<IPortfolioService> _serviceResolver;

        #endregion

        #region Constructor
        public NetworkTokenService(
            IRepository<NetworkToken> networkTokenrepository,
            IRepository<UserInvestment> userInvestmentrepository,
            IRepository<Calendar> calendarRepository,
            ICommanService commanService,
            ServiceResolver<IPortfolioService> serviceResolver)
        {
            _networkTokenRepository = networkTokenrepository;
            _userInvestmentRepository = userInvestmentrepository;
            _calendarRepository = calendarRepository;
            _commanService = commanService;
            _serviceResolver = serviceResolver;
        }
        #endregion
        public async Task Delete(int networkId)
        {
            var token = await GetById(networkId);
            if (token != null)
                await _networkTokenRepository.DeleteAsync(token);
        }

        public async Task<List<NetworkToken>> GetAllTokensByNetworkId(int networkId)
        {
            return await (await _networkTokenRepository.GetAllAsync(x => x.NetworkId == networkId))
                  .Include(x => x.Network).ToListAsync();
        }

        public async Task<IPagedList<NetworkToken>> GetAllTokensPagedListByNetworkId(int pageNumber = 0, int pageSize = int.MaxValue)
        {
            var token = await (await _networkTokenRepository.GetAllAsync()).Include(x => x.Network).ToPagedListAsync(pageNumber, pageSize);
            return token;
        }

        public async Task<NetworkToken> GetById(int id)
        {
            return await (await _networkTokenRepository.GetAllAsync(x => x.Id == id))
             .Include(x => x.Network).Include(x => x.userInvestment).FirstOrDefaultAsync();
        }

        public async Task InsertOrUpdate(TokenManagementModel model)
        {
            DateTime tokenCreatedDate = DateTime.UtcNow;
            var token = await GetById(model.Id);
            if (token != null)
            {
                tokenCreatedDate = token.CreatedOnDateTimeUTC;
                token.Name = model.Name;
                token.Address = model.Address;
                token.UpdatedOnDateTimeUTC = DateTime.UtcNow;
                token.NetworkId = model.NetworkId;
                token.Network = null;
                token.Symbol = model.Symbol;
                await _networkTokenRepository.UpdateAsync(token);
            }
            else
            {
                try
                {
                    var insertedToken = new NetworkToken()
                    {
                        Address = model.Address,
                        CreatedOnDateTimeUTC = tokenCreatedDate,
                        Name = model.Name,
                        NetworkId = model.NetworkId,
                        UpdatedOnDateTimeUTC = DateTime.UtcNow,
                        UserId = model.UserId,
                        Symbol = model.Symbol
                    };
                    await _networkTokenRepository.InsertAsync(insertedToken);
                    model.CreatedOnDateTimeUtc = tokenCreatedDate;
                    model.Id = insertedToken.Id;
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                }
            }
            await AssociateTokenToInvestment(model, tokenCreatedDate);
        }

        private async Task AssociateTokenToInvestment(TokenManagementModel model, DateTime tokenCreatedDate)
        {
            bool isTokenNeedToUpdate = false;
            bool isRemoveExistingCalendar = false;
            int investmentId = Convert.ToInt32(model.InvestmentId);
            if (investmentId > 0)
            {
                /// first remove existing associated token from investment table
                var existingInvestment = (await _userInvestmentRepository.GetAllAsync(x => x.TokenId == model.Id)).FirstOrDefault();
                if (existingInvestment != null)
                {
                    /// check existing investment or new investment is same or not. If not then remove token from investment.
                    if (existingInvestment.Id != model.InvestmentId)
                    {
                        var updateInvestment = _userInvestmentRepository.GetByIdAsync(existingInvestment.Id).Result;
                        updateInvestment.TokenId = null;
                        await _userInvestmentRepository.UpdateAsync(updateInvestment);
                        isTokenNeedToUpdate = true;
                        isRemoveExistingCalendar = true;
                    }
                }
                else
                {
                    isTokenNeedToUpdate = true;
                }

                if (isTokenNeedToUpdate)
                {
                    var investment = await (await _userInvestmentRepository.GetAllAsync(x => x.Id == investmentId)).Include(x => x.DynamicDistributions).FirstOrDefaultAsync();
                    if (investment != null)
                    {
                        investment.TokenId = model.Id;
                        await _userInvestmentRepository.UpdateAsync(investment);
                    }

                    /// If TGE is set then add Calendar
                    if (investment.DynamicDistributions != null && investment.DynamicDistributions.Any())
                    {
                        await AddCalendar(model, investment, isRemoveExistingCalendar, tokenCreatedDate);
                    }
                }
            }
        }

        private async Task AddCalendar(TokenManagementModel token, UserInvestment investment, bool isRemoveExistingCalendar, DateTime tokenCreatedDate)
        {
            /// firstly remove existing data
            if (isRemoveExistingCalendar)
            {
                List<Calendar> existingCalendar = await (await _calendarRepository.GetAllAsync(x => x.TokenId == investment.TokenId)).ToListAsync();
                if (!existingCalendar.Any())
                {
                    await _calendarRepository.DeleteAllAsync(existingCalendar);
                }
            }

            /// add calendar data
            List<Calendar> calendars = new List<Calendar>();
            decimal investedAmount = investment.InvestedAmount;
            foreach (var distribution in investment.DynamicDistributions)
            {
                Calendar calendar = new Calendar
                {
                    TokenId = token.Id,
                    Date = tokenCreatedDate.AddMonths(Convert.ToInt32(distribution.Peroid)),
                    Goal = Math.Round((investedAmount * Convert.ToDecimal(distribution.TokenPercentage)) / 100)
                };
                calendars.Add(calendar);
            }
            await _calendarRepository.InsertAllAsync(calendars);
        }

        public async Task<List<NetworkToken>> GetAll()
        {
            return await (await _networkTokenRepository.GetAllAsync()).ToListAsync();
        }

        public async Task<List<NetworkToken>> GetAllByInvestmentId(int investmentId)
        {
            List<int?> tokenIds = new List<int?>();
            var investments = await _userInvestmentRepository.GetAllAsync();
            if (investmentId > 0)
            {
                tokenIds = investments.Where(x => x.Id != investmentId && x.TokenId != null).Select(x => x.TokenId).ToList();
            }
            else
            {
                tokenIds = investments.Where(x => x.TokenId != null).Select(x => x.TokenId).ToList();
            }
            List<NetworkToken> token = new List<NetworkToken>();
            try
            {
                token = await (await _networkTokenRepository.GetAllAsync(x => !tokenIds.Contains(x.Id))).ToListAsync();
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
            return token;
        }

        public async Task<bool> IsTokenExist(string contractAddress)
        {
            bool isExist = false;
            var networkToken = (await _networkTokenRepository.GetAllAsync(x => x.Address.ToLower().Trim() == contractAddress.ToLower().Trim())).FirstOrDefault();
            if (networkToken != null)
            {
                isExist = true;
            }
            return isExist;
        }

        public async Task<NetworkToken> GetByAddress(string address)
        {
            var token = (await _networkTokenRepository.GetAllAsync(x => x.Address.Trim().ToLower() == address.Trim().ToLower())).FirstOrDefault();
            return token;
        }

        public async Task UpdateHighAndLowPrice()
        {
            try
            {
                var networkTokens = await GetWalletToken(null);
                if (networkTokens != null)
                {
                    foreach (var networkToken in networkTokens)
                    {
                        try
                        {
                            Tuple<decimal, decimal> prices = new Tuple<decimal, decimal>(0, 0);
                            if (!string.IsNullOrEmpty(networkToken.Symbol))
                            {
                                prices = await _commanService.GetCurrentAndLast24HrsPrice(networkToken.Symbol, networkToken.NetworkId);
                            }
                            decimal currentPrice = prices.Item1;

                            if (currentPrice > Convert.ToDecimal(networkToken.AllTimeHighValue))
                            {
                                networkToken.AllTimeHighValue = currentPrice;
                            }
                            if (currentPrice < Convert.ToDecimal(networkToken.AllTimeLowValue))
                            {
                                networkToken.AllTimeLowValue = currentPrice;
                            }
                            networkToken.CurrentPriceUSD = currentPrice;
                            decimal Amount24HrsDiff = Math.Round(currentPrice - prices.Item2,2);
                            networkToken.Price24HrsDifference = Amount24HrsDiff;
                            await _networkTokenRepository.UpdateAsync(networkToken);

                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message;
            }
        }

        public async Task<List<NetworkToken>> GetWalletToken(List<int> networkIds, int userId = 0)
        {
            List<int?> investmentTokenIds = new List<int?>();
            List<UserInvestment> userInvestments = new List<UserInvestment>();
            if (userId > 0)
            {
                userInvestments = await (await _userInvestmentRepository.GetAllAsync(x => x.TokenId != null && x.User.Id == userId)).ToListAsync();
            }
            else
            {
                try
                {
                    userInvestments = await (await _userInvestmentRepository.GetAllAsync(x => x.TokenId != null)).ToListAsync();
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                }
            }
            if (networkIds != null)
            {
                investmentTokenIds = userInvestments.Where(x => networkIds.Contains(x.MonitoringTypeId)).Select(x => x.TokenId).ToList();
            }
            else
            {
                investmentTokenIds = userInvestments.Select(x => x.TokenId).ToList();
            }
            var token = await (await _networkTokenRepository.GetAllAsync(x => investmentTokenIds.Contains(x.Id))).OrderBy(x => x.NetworkId).ToListAsync();
            return token;
        }

        public async Task<IPagedList<TokenOverviewModel>> GetTokenOverview(int userId, string networkIds, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            List<NetworkToken> networkTokens = new List<NetworkToken>();
            bool isNeedToFilter = false;
            List<int> networkList = new List<int>();
            if (networkIds == "0" || string.IsNullOrEmpty(networkIds))
            {
                isNeedToFilter = false;
            }
            else
            {
                var ids = networkIds.Split(",");
                if (ids.Length > 1)
                {
                    var listOfArray = ids.Select(n => Convert.ToInt32(n)).ToList();
                    networkList.AddRange(listOfArray);
                    isNeedToFilter = true;
                }
                else
                {
                    var value = Convert.ToInt32(ids[0]);
                    if (value == 0)
                    {
                        isNeedToFilter = false;
                    }
                    else
                    {
                        networkList.Add(Convert.ToInt32(ids[0]));
                        isNeedToFilter = true;
                    }
                }
            }

            if (isNeedToFilter)
            {
                networkTokens = await (await _networkTokenRepository.GetAllAsync(x => x.UserId == userId && networkList.Contains(x.NetworkId))).ToListAsync();
            }
            else
            {
                networkTokens = await (await _networkTokenRepository.GetAllAsync(x => x.UserId == userId)).ToListAsync();
            }

            var tokenOverview = networkTokens.Select(x => new TokenOverviewModel
            {
                TokenName = x.Name,
                TokenPrice = x.CurrentPriceUSD,
                Id = x.Id,
                TokenUpDown = x.Price24HrsDifference,
                TokenHolding = GetHoldingAmount(x.NetworkId,x.Address, x.CurrentPriceUSD).Result,
                TokenProfitLoss = GetProfileLoss(x.Id,Convert.ToDecimal(x.CurrentPriceUSD), userId).Result
            });
            var tokenModel = await tokenOverview.AsQueryable().ToPagedListAsync(pageIndex, pageSize);
            return tokenModel;
        }

        private async Task<decimal> GetHoldingAmount(int networkId,string address,decimal? price)
        {
            decimal holdingAmount = 0;
            var portfolioService = _serviceResolver(networkId.ToString());
            var apiKey = _commanService.GetApiByKey((int)ApiKeyType.EthPlorer, true);
            var addressDetails = await portfolioService.GetAllTokenByAddress(apiKey, address);
            var result = JsonConvert.DeserializeObject<AddressDetailsResponse>(addressDetails);
            if(result != null)
            {
                var tokenCount = result.tokens.Count();
                holdingAmount = Math.Round(tokenCount * Convert.ToDecimal(price),2);
            }
            return holdingAmount;
        }

        private async Task<decimal> GetProfileLoss(int tokenId,decimal price, int userId)
        {
            decimal profitLoss = 0;
            var investmentData = await (await _userInvestmentRepository.GetAllAsync(x => x.TokenId == tokenId && x.User.Id == userId)).ToListAsync();
            if(investmentData.Count() > 0)
            {
                decimal InvestedAmount = investmentData.Sum(x => x.InvestedAmount);
                int totalTokenCount = investmentData.Sum(x => x.NumberOfToken);
                int receivedToken = (await _calendarRepository.GetAllAsync(x => x.TokenId == tokenId && x.Date.Date <= DateTime.UtcNow.Date)).Count();
                decimal liquidValue = Math.Round(price * totalTokenCount, 2);
                decimal lockedValue = Math.Round(price * receivedToken, 2);
                profitLoss = Math.Round(InvestedAmount - (liquidValue + lockedValue) * price, 2);
            }
            
            return profitLoss;
        }
    }
}
