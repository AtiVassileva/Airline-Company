namespace AirlineCompany.Web.Models
{
    public class ReservationListViewModel
    {
        public Guid Id { get; set; }

        public DateTime ReservationDate { get; set; }

        public string FlightNumber { get; set; } = null!;
        public string From { get; set; } = null!;
        public string To { get; set; } = null!;
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }

        public string PassengerFullName { get; set; } = null!;

        public string TicketType { get; set; } = null!;
        public string LuggageType { get; set; } = null!;
        public string Status { get; set; } = null!;

        public bool IsCancelled { get; set; }
    }
}