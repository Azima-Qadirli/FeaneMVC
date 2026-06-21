using System.ComponentModel.DataAnnotations;

namespace Feane.ViewModels.DiscountedProduct
{
    public class DiscountedProductCreateVM
    {
        [Required]
        public int DishId { get; set; }
        [Required]

        public double Percentage { get; set; }

    }
}
