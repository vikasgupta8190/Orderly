using System.ComponentModel.DataAnnotations;

namespace Orderly.Models.ViewModels
{
    public class SignupViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
