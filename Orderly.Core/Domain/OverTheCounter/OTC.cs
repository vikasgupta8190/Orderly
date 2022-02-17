using Orderly.Core.Domain.Common;
using Orderly.Core.Domain.Tokens;

using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Orderly.Core.Domain.OverTheCounter
{
    public class OTC : BaseEntity
    {
        public string Type { get; set; }
        public int CreatedByUserId { get; set; }
        public int TokenId { get; set; }
        public int TokenQty { get; set; }
        public decimal Lockup { get; set; }
        public decimal Vesting { get; set; }
        public decimal PricePerToken { get; set; }
        public decimal TotalAmount { get; set; }
        public string Currency { get; set; }
        public string ContactDetails { get; set; }
        public string TelegramUsername { get; set; }
        public string Email { get; set; }
        public bool IsArchive { get; set; }
        public DateTime CreatedOnDateTimeUTC { get; set; }

        [ForeignKey("TokenId")]
        public virtual NetworkToken networkTokens { get; set; }       
    }
}
