using System.ComponentModel.DataAnnotations;

namespace Feane.ViewModels.DiscountedProduct
{
    public class DiscountedProductUpdateVM

    {
        public int Id { get; set; }
        [Required]
        public int DishId { get; set; }
        [Required]
        public double Percentage { get; set; }
    }
}
