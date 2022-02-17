using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Orderly.Models.Dashboard
{
    public class DashboardModel
    {
        public DashboardModel()
        {
            AvailableNetworks = new List<SelectListItem>();
        }
        public decimal LiquidValue { get; set; }
        public decimal? LiquidATH { get; set; }
        public decimal? LiquidATL { get; set; }
        public decimal LockedValue { get; set; }
        public decimal Last24HrsLockedValue { get; set; }
        public decimal? LockedATH { get; set; }
        public decimal? LockedATL { get; set; }
        public decimal AssetBalance { get; set; }
        public string LastTwentyHoursDifference { get; set; }
        public string UpDownPercentage { get; set; }
        public List<SelectListItem> AvailableNetworks { get; set; }
        public TokenSearchModel TokenSearchModel { get; set; }
       
    }
}
