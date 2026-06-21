using System.ComponentModel.DataAnnotations;

namespace Feane.ViewModels.BookTable
{
    public class BookTableUpdateVM
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [MinLength(3)]
        public string Name { get; set; } = string.Empty;
        [Required]
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
