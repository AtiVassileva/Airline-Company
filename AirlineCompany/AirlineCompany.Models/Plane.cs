namespace AirlineCompany.Models
{
    public class Plane : BaseEntity
    {
        public string Model { get; set; } = null!;
        public int TotalSeats { get; set; }
        public int EconomySeats { get; set; }
        public int BusinessSeats { get; set; }
        public int FirstClassSeats { get; set; }

        public ICollection<Flight> Flights { get; set; } = new List<Flight>();
    }
}