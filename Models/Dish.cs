using Feane.Models.Base;

namespace Feane.Models
{
    public class Dish : BaseEntity
    {
        public string ImageName { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal DishPrice { get; set; } 

    }
}
