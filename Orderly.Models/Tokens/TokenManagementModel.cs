using Microsoft.AspNetCore.Mvc.Rendering;

using Orderly.Helpers;
using Orderly.Models.Comman;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Orderly.Models.Tokens
{
    public record TokenManagementModel : BaseEntityModel
    {
        public TokenManagementModel()
        {
            AvailableNetworks = new List<SelectListItem>();
            AvailableInvestment = new List<SelectListItem>();
        }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public string Address { get; set; }
        public int NetworkId { get; set; }
        [DisplayName(ModelComponenteNames.InvestmentId)]
        public int? InvestmentId { get; set; }
        public int? UserId { get; set; }
        public decimal? CurrentPriceUSD { get; set; }
        public decimal? AllTimeHighValue { get; set; }
        public decimal? AllTimeLowValue { get; set; }
        public decimal? DailyRateDiff { get; set; }
        public List<SelectListItem> AvailableInvestment { get; set; }
        public DateTime CreatedOnDateTimeUtc { get; set; }
        public DateTime UpdatedOnDateTimeUtc { get; set; }
        public List<SelectListItem> AvailableNetworks { get; set; }
    }
}
