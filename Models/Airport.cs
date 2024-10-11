namespace FinalProject.Models
{
    public class Airport
    {
        public int? AirportID { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public int? CityID { get; set; }

        public City? City { get; set; }

        public virtual List<DepartureInfo>? DepartureInfos { get; set; }
        public virtual List<ArrivalInfo>? ArrivalInfos { get; set; }
        
        public List<Lounge>? Lounges { get; set; } = new List<Lounge>();
        
    }
}
