using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderly.Models.Analyzer
{
    public class DailyPrice
    {
        public string UTCDate { get; set; }
        public string unixTimeStamp { get; set; }
        public string value { get; set; }
    }

    public class DailyPriceResponseModel
    {
        public string status { get; set; }
        public string message { get; set; }
        public List<DailyPrice> result { get; set; }
    }
}
