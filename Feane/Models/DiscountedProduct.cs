using Feane.Models.Base;

namespace Feane.Models
{
    public class DiscountedProduct : BaseEntity
    {
        public string ImageUrl { get; set; } = null!;
        public string Image { get; set; } = null!;

        public string Name { get; set; } = null!;
        public int Percentage { get; set; }
    }
}

