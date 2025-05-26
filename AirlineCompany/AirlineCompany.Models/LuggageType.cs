namespace AirlineCompany.Models
{
    public class LuggageType : NamedEntity
    {
        public int MaxWeight { get; set; }
        public int MaxHeight { get; set; }
        public int MaxDepth { get; set; }

        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}