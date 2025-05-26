namespace AirlineCompany.Models
{
    public class Passenger : BaseEntity
    {
        public string FirstName { get; set; } = null!;
        public string? MiddleName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }

        public string PassportNumber { get; set; } = null!;
        public string PersonalIdNumber { get; set; } = null!;
        public string Nationality { get; set; } = null!;

        public Guid ReservationId { get; set; }
        public Reservation Reservation { get; set; } = null!;
    }
}