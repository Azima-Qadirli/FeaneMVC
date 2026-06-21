using Feane.Models.Base;

namespace Feane.Models
{
    public class Customers : BaseEntity
    {
        public string ImageName { get; set; } = null!;
        public string Name { get; set; } = null!; 
       public string Comment { get; set; } = null!;

    }
}
