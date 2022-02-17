using Orderly.Models.Comman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderly.Models.Investment
{
    public partial record InvestmentModel : BaseEntityModel
    {
        public string CoinImage { get; set; }
        public string CoinName { get; set; }
        public string CoinAbbreviation { get; set; }
        public string WebsiteLink { get; set; }
        public DateTime InvestedOnDateTime { get; set; }
        public decimal AmountInvested { get; set; }
        public decimal TransactionFee { get; set; }
    }
}
