using System.ComponentModel.DataAnnotations;

namespace Feane.ViewModels.Account
{
    public class RegisterVM
    {
        [Required]
        [MaxLength(50)]
        [MinLength(5)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(100)]
        [MinLength(6)]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MaxLength(20)]
        [MinLength(6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [MaxLength(20)]
        [MinLength(6)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}