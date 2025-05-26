using System.ComponentModel.DataAnnotations;

namespace AirlineCompany.Web.Models
{
    public class DestinationFormModel
    {
        public Guid? Id { get; set; } 

        [Required(ErrorMessage ="Моля въведете име на град!")]
        [Display(Name = "Град")]
        public string CityName { get; set; } = null!;

        [Required(ErrorMessage = "Моля въведете име на държава!")]
        [Display(Name = "Държава")]
        public string CountryName { get; set; } = null!;

        [Required(ErrorMessage = "Моля въведете име на летище!")]
        [Display(Name = "Летище")]
        public string AirportName { get; set; } = null!;

        public byte[]? VersionNo { get; set; }
    }
}