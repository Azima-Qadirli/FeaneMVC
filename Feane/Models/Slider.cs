using Feane.Models.Base;

namespace Feane.Models
{
    public class Slider : BaseEntity
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
