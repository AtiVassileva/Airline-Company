using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace AirlineCompany.Models
{
    public class Reservation : BaseEntity
    {
        public DateTime ReservationDate { get; set; } = DateTime.UtcNow;
        public bool IsCancelled { get; set; } = false;

        [Required]
        public string UserId { get; set; } = null!;
        public IdentityUser User { get; set; } = null!;

        [Required]
        public Guid FlightId { get; set; }
        public Flight Flight { get; set; } = null!;

        [Required]
        public Guid StatusId { get; set; }
        public Status Status { get; set; } = null!;

        [Required]
        public Guid TicketId { get; set; }
        public TicketType TicketType { get; set; } = null!;

        [Required]
        public Guid LuggageId { get; set; }
        public LuggageType LuggageType { get; set; } = null!;

        [Required]
        public Guid PassengerId { get; set; }
        public Passenger Passenger { get; set; } = null!;
    }
}