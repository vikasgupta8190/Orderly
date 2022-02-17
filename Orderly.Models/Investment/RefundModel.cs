using System.ComponentModel.DataAnnotations;

namespace Orderly.Models.Investment
{
    public class RefundModel
    {
        public int Id { get; set; }
        [Required]
        public decimal RefundAmount { get; set; }
    }
}
