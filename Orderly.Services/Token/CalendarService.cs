using Microsoft.EntityFrameworkCore;

using Orderly.Core.Domain.Investment;
using Orderly.Core.Domain.Tokens;
using Orderly.Models.Comman;
using Orderly.Models.Dashboard;
using Orderly.Models.Enums;
using Orderly.Repositories;

using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderly.Services.Token
{
    public class CalendarService : ICalendarService
    {
        #region Properties
        private readonly IRepository<Calendar> _calendarRepository;
        private readonly IRepository<UserInvestment> _investmentRepository;

        #endregion

        #region Constructor
        public CalendarService(IRepository<Calendar> calendarRepository,
            IRepository<UserInvestment> investmentRepository)
        {
            _calendarRepository = calendarRepository;
            _investmentRepository = investmentRepository;
        }
        #endregion

        #region Methods
        public async Task<List<Calendar>> GetListCalendars(int userId, CalendarTypes type)
        {
            var list = (await _calendarRepository.GetAllAsync(x => x.Token.UserId == userId))
                .Include(x => x.Token)
                .ThenInclude(x => x.Network)
                .ToList();
            switch (type)
            {
                case CalendarTypes.OnGoing:
                    list = list.Where(x => x.Date.Date <= DateTime.UtcNow.Date).ToList();
                    break;
                case CalendarTypes.UpComming:
                    list = list.Where(x => x.Date.Date > DateTime.UtcNow.Date).ToList();
                    break;
            }
            return list;
        }

        public async Task<IPagedList<Calendar>> GetPagedListCalendars(int userId, CalendarTypes type, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var list = await GetListCalendars(userId, type);
            return await list.AsQueryable().ToPagedListAsync(pageIndex, pageSize);
        }

        public async Task<IPagedList<UserInvestment>> GetUpComingTokens(int userId, CalendarTypes type, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var ongoingTokens = (await _calendarRepository.GetAllAsync()).Select(x => x.TokenId).Distinct();
            var investments = (await _investmentRepository.GetAllAsync(x => x.TokenId != null))
                .Include(x => x.networkTokens)
                .ThenInclude(x => x.Network)
                .Where(x => !ongoingTokens.Contains(x.TokenId.Value));
            return await investments.AsQueryable().ToPagedListAsync(pageIndex, pageSize);
        }

        public async Task<IPagedList<TokenModel>> GetCalendarsTokens(int userId, bool isUpcoming, string networkIds, int nextDays, int prevDays, int pageSize = int.MaxValue, int pageIndex = 0)
        {
            bool isNeedToFilter = false;
            List<NetworkToken> networkTokens = new List<NetworkToken>();
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

            List<Calendar> calendars = new List<Calendar>();
            if (isNeedToFilter)
            {
                calendars = (await _calendarRepository.GetAllAsync(x => x.Token.UserId == userId && networkList.Contains(x.Token.NetworkId)))
                            .Include(x => x.Token)
                            .ThenInclude(x => x.Network)
                            .ToList();
            }
            else
            {
                calendars = (await _calendarRepository.GetAllAsync(x => x.Token.UserId == userId))
                             .Include(x => x.Token)
                             .ThenInclude(x => x.Network)
                             .ToList();
            }

            if (calendars != null)
            {
                if (isUpcoming)
                {
                    DateTime next30Days = DateTime.UtcNow.Date.AddDays(nextDays);
                    calendars = calendars.Where(x => x.Date.Date > DateTime.UtcNow.Date && x.Date.Date <= next30Days).ToList();
                }
                else
                {
                    DateTime last30Days = DateTime.UtcNow.Date.AddDays(-prevDays);
                    calendars = calendars.Where(x => x.Date.Date > last30Days && x.Date.Date <= DateTime.UtcNow.Date).ToList();
                }
            }
            List<TokenModel> tokenModels = new List<TokenModel>();
            tokenModels = calendars.Select(x => new TokenModel
            {
                TokenName = x.Token.Name,
                TokenDate = x.Date,
                TokenValue = x.Goal.ToString(),
                LeftTime = Convert.ToInt32((x.Date.Date - DateTime.UtcNow.Date).TotalDays)
            }).ToList();
            tokenModels.ForEach(x => { if (x.LeftTime < 0) x.LeftTime = ((-1) * x.LeftTime); else x.LeftTime = x.LeftTime; });
            var tokenModel = await tokenModels.AsQueryable().ToPagedListAsync(pageIndex, pageSize);
            return tokenModel;
        }
        #endregion
    }
}
