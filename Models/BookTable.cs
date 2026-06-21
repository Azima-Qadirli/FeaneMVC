using Feane.Models.Base;

namespace Feane.Models
{
    public class BookTable : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int PersonNumber { get; set; }
        public DateTime Date { get; set; }
    }
}
