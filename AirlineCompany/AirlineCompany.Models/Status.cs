namespace AirlineCompany.Models
{
    public class Status : NamedEntity
    {
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}