namespace AirlineCompany.Web.Models
{
    public class FlightReportViewModel
    {
        public Guid FlightId { get; set; }
        public string FlightNumber { get; set; } = null!;
        public string From { get; set; } = null!;
        public string To { get; set; } = null!;
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }
        public int ActiveReservationsCount { get; set; }
        public int CancelledReservationsCount { get; set; }
    }
}