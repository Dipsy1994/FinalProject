namespace FinalProject.Models
{
    public class Airline
    {
        public int? AirlineID { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }

        public List<Flight>? Flights { get; set; } = new List<Flight>();
        public List<Lounge>? Lounges { get; set; } = new List<Lounge>();
    }
}
