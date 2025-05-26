using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace AirlineCompany.Models
{
    public class Reservation : BaseEntity
    {
        public DateTime ReservationDate { get; set; } = DateTime.UtcNow;
        public bool IsCancelled { get; set; } = false;

        public Guid UserId { get; set; }

        public Guid FlightId { get; set; }
        public Flight Flight { get; set; } = null!;

        public Guid StatusId { get; set; }
        public Status Status { get; set; } = null!;

        public Guid TicketId { get; set; }
        public TicketType TicketType { get; set; } = null!;

        public Guid LuggageId { get; set; }
        public LuggageType LuggageType { get; set; } = null!;

        public ICollection<Passenger> Passengers { get; set; } = new List<Passenger>();
    }
}