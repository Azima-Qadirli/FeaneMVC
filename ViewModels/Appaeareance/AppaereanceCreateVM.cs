using System.ComponentModel.DataAnnotations;

namespace Feane.ViewModels.Appaeareance
{
    public class AppaereanceCreateVM
    {
        [ Required]
        [MaxLength(50)]
        public string Title { get; set; } = string.Empty;
        [Required]
        public IFormFile ImageName { get; set; }
        [Required]
        [MaxLength(50)]
        public string Description { get; set; } = string.Empty;
    }
}
