using System.ComponentModel.DataAnnotations;

namespace Feane.ViewModels.BookTable
{
    public class BookTableCreateVM
    {
        [Required]
        [MaxLength(50)]
        [MinLength(3)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        public string PhoneNumber { get; set; } = string.Empty;
        [EmailAddress]
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public int PersonNumber { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
