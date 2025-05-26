using System.ComponentModel.DataAnnotations;

namespace AirlineCompany.Models
{
    public class Destination : BaseEntity
    {
        [Required] public string CityName { get; set; } = null!;
        [Required] public string CountryName { get; set; } = null!;
        [Required] public string AirportName { get; set; } = null!;

        public ICollection<Flight> Departures { get; set; } = new HashSet<Flight>();
        public ICollection<Flight> Arrivals { get; set; } = new HashSet<Flight>();
    }
}