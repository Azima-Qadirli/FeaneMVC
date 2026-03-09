using System.ComponentModel.DataAnnotations;

namespace Feane.ViewModels.DiscountedProduct
{
    public class DiscountedProductGetVM
    {
        public int Id { get; set; }
        [Required]
        public string ImageUrl { get; set; } = string.Empty;
        [Required]
        public string Image { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        [Required]
        public int Percentage { get; set; }
    }
}
