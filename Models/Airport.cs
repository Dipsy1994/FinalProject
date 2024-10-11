namespace FinalProject.Models
{
    public class Airport
    {
        public int? AirportID { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public int? CityID { get; set; }

        public City? City { get; set; }
        public List<Flight>? Departures { get; set; } = new List<Flight>();
        public List<Flight>? Arrivals { get; set; } = new List<Flight>();
        public List<Lounge>? Lounges { get; set; } = new List<Lounge>();
    }
}
