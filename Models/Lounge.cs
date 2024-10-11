namespace FinalProject.Models
{
    public class Lounge
    {
        public int? LoungeID { get; set; }
        public string? Name { get; set; }
        public int? AirportID { get; set; }
        public int? AirlineID { get; set; } // Nullable if it's not associated with any airline
        public int? Capacity { get; set; }

        public Airport? Airport { get; set; }
        public Airline? Airline { get; set; }
    }

}
