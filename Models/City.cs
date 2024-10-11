namespace FinalProject.Models
{
    public class City
    {
        public int? CityID { get; set; }
        public string? Name { get; set; }
        public string? Country { get; set; }

        public List<Airport>? Airports { get; set; } = new List<Airport>();
    }
}
