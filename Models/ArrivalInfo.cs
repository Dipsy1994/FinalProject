namespace FinalProject.Models
{
    public class ArrivalInfo
    {
        public int? ArrivalInfoID { get; set; }
        public int? AirportID { get; set; }
        public DateTime? Time { get; set; }
        public string? Gate { get; set; }

        public Airport? Airport { get; set; }
        public List<Flight>? Flights { get; set; } = new List<Flight>();
    }

}
