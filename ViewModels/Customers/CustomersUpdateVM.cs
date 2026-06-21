using System.ComponentModel.DataAnnotations;

namespace Feane.ViewModels.Customers
{
    public class CustomersUpdateVM
    {
        public int Id { get; set; }
        public IFormFile? ImageName { get; set; }
        [Required]
        [MaxLength(50)]
        [MinLength(3)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        public string Comment { get; set; } = string.Empty;

    }
}
