using System.ComponentModel.DataAnnotations;

namespace Feane.ViewModels.DiscountedProduct
{
    public class DiscountedProductUpdateVM
    {
        public int Id { get; set; }
        [Required]
        public string? ImageUrl { get; set; }
        [Required]
        public string? Image { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        [Required]
        public int Percentage { get; set; }
    }
}
