using System.ComponentModel.DataAnnotations;

namespace AirlineCompany.Models
{
    public class NamedEntity : BaseEntity
    {
        [Required]
        public string Name { get; set; } = null!; 
    }
}