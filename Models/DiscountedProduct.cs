using Feane.Models.Base;

namespace Feane.Models
{
    public class DiscountedProduct : BaseEntity
    {
        public int DishId { get; set; }
        public Dish Dish { get; set; } = null!;
        public double Percentage { get; set; }
    }
}
