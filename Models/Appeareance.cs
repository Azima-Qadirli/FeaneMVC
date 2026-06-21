using Feane.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Feane.Models
{
    public class Appeareance : BaseEntity
    { 
    public string Title { get; set; } = null!;
        
    public string ImageName { get; set; } = null!;
    
    public string Description { get; set; }



    }
}
