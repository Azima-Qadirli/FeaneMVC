    using System.ComponentModel.DataAnnotations;

namespace Feane.ViewModels.Account
{
    public class LoginVM
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MaxLength(20)]
        [MinLength(6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}