using AirlineCompany.Web.Attributes;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace AirlineCompany.Web.Models
{
    public class FlightFormModel
    {
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "Моля, въведете номер на полет!")]
        [Display(Name = "Номер на полета")]
        public string FlightNumber { get; set; } = null!;

        [Required]
        [Display(Name = "Вид самолет")]
        public Guid PlaneId { get; set; }

        [Required]
        [Display(Name = "Начална дестинация")]
        public Guid DepartureDestinationId { get; set; }

        [Required]
        [Display(Name = "Крайна дестинация")]
        [DifferentFrom("DepartureDestinationId")]
        public Guid ArrivalDestinationId { get; set; }

        [Required(ErrorMessage = "Моля, изберете време на излитане!")]
        [Display(Name = "Време на излитане")]
        public DateTime DepartureTime { get; set; }

        [Required(ErrorMessage = "Моля, изберете време на кацане!")]
        [Display(Name = "Време на кацане")]
        [ArrivalAfterDeparture("DepartureTime")]
        public DateTime ArrivalTime { get; set; }

        public byte[]? VersionNo { get; set; }

        public List<SelectListItem> Planes { get; set; } = new();
        public List<SelectListItem> Destinations { get; set; } = new();
    }
}