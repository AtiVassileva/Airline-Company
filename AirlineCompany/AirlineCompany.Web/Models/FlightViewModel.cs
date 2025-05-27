namespace AirlineCompany.Web.Models
{
    public class FlightViewModel
    {
        public Guid Id { get; set; }
        public string FlightNumber { get; set; } = null!;
        public string PlaneModel { get; set; } = null!;
        public string DepartureCity { get; set; } = null!;
        public string ArrivalCity { get; set; } = null!;
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
    }
}