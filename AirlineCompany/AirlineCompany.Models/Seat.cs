namespace AirlineCompany.Models
{
    public class Seat : BaseEntity
    {
        public string Number { get; set; } = null!;
        public bool IsAvailable { get; set; } = true;

        public Guid FlightId { get; set; }
        public Flight Flight { get; set; } = null!;
    }
}