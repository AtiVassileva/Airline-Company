using System.ComponentModel.DataAnnotations;

namespace AirlineCompany.Web.Models
{
    public class PlaneFormModel
    {
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "Моля изберете модел на самолета!")]
        [Display(Name = "Модел на самолета")]
        public string PlaneModel { get; set; } = null!;

        [Range(1, 1000, ErrorMessage = "Моля въведете число в интервала 1-1000!")]
        [Display(Name = "Общ брой места")]
        public int TotalSeats { get; set; }

        [Range(0, 1000, ErrorMessage = "Моля въведете число в интервала 0-1000!")]
        [Display(Name = "Брой места икономична класа")]
        public int EconomySeats { get; set; }

        [Range(0, 1000, ErrorMessage = "Моля въведете число в интервала 0-1000!")]
        [Display(Name = "Брой места бизнес класа")]
        public int BusinessSeats { get; set; }

        [Range(0, 1000, ErrorMessage = "Моля въведете число в интервала 0-1000!")]
        [Display(Name = "Брой места първа класа")]
        public int FirstClassSeats { get; set; }

        public byte[]? VersionNo { get; set; }
    }
}