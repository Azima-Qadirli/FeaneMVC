
using System.ComponentModel.DataAnnotations;

namespace Feane.ViewModels.Slider
{
    public class SliderUpdateVM
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [MinLength(3)]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;

    }
}
