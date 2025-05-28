using AirlineCompany.Web.Attributes;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace AirlineCompany.Web.Models
{
    public class SearchFlightViewModel
    {
        [Required(ErrorMessage = "Моля, изберете начална дестинация!")]
        [Display(Name = "Начална дестинация")]
        public Guid DepartureDestinationId { get; set; }

        [Required(ErrorMessage = "Моля, изберете крайна дестинация!")]
        [Display(Name = "Крайна дестинация")]
        [DifferentFrom("DepartureDestinationId")]
        public Guid ArrivalDestinationId { get; set; }

        public List<SelectListItem> Destinations { get; set; } = new();
        public List<FlightViewModel> Flights { get; set; } = new();
    }
}