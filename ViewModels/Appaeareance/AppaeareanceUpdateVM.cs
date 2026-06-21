using System.ComponentModel.DataAnnotations;

namespace Feane.ViewModels.Appaeareance
{
    public class AppaeareanceUpdateVM
    {

        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [MinLength(3)]
        public string Title { get; set; } = string.Empty;
        public IFormFile? ImageName { get; set; }
        [Required]
        [MaxLength(50)]
        [MinLength(10)]
        public string Description { get; set; } = string.Empty;
    }
}
