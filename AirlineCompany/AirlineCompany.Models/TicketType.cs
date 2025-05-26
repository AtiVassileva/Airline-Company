namespace AirlineCompany.Models
{
    public class TicketType : NamedEntity
    {
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}