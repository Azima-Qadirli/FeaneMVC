using System.ComponentModel.DataAnnotations;

namespace Feane.ViewModels.Dish
{
    public class DishCreateVM
    {
        [Required]
        public IFormFile Image { get; set; }
        [Required]
        [MaxLength(50)]
        [MinLength(3)]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public decimal DishPrice { get; set; }
    }
}
