namespace AirlineCompany.Models
{
    public class FlightSeatAvailability : BaseEntity
    {
        public Guid FlightId { get; set; }
        public Flight Flight { get; set; } = null!;

        public int EconomySeatsLeft { get; set; }
        public int BusinessSeatsLeft { get; set; }
        public int FirstClassSeatsLeft { get; set; }
    }
}