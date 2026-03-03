using Feane.Models.Base;

namespace Feane.Models
{
    public class Dish : BaseEntity
    {
        public string ImageUrl { get; set; } = null!;
        public string Image { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
