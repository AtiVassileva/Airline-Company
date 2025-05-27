using System.ComponentModel.DataAnnotations;
using static AirlineCompany.Models.Common.ModelConstants;

namespace AirlineCompany.Models
{
    public class Flight : BaseEntity
    {
        public string FlightNumber { get; set; } = null!;
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }

        [Required]
        public FlightStatus FlightStatus { get; set; }

        [Required]
        public Guid PlaneId { get; set; }
        public Plane Plane { get; set; } = null!;

        [Required] public Guid DepartureDestinationId { get; set; }
        [Required] public Guid ArrivalDestinationId { get; set; }

        public Destination DepartureDestination { get; set; } = null!;
        public Destination ArrivalDestination { get; set; } = null!;

        [Required] public Guid SeatAvailabilityId { get; set; }
        public FlightSeatAvailability SeatAvailability { get; set; } = null!;

        public ICollection<Seat> Seats { get; set; } = new HashSet<Seat>();
        public ICollection<Reservation> Reservations { get; set; } = new HashSet<Reservation>();
    }
}