namespace FinalProject.Models
{
    public class Flight
    {
        public int? FlightID { get; set; }
        public string? Number { get; set; }
        public int? AirlineID { get; set; }
        public int? DepartureInfoID { get; set; }
        public int? ArrivalInfoID { get; set; }
        public decimal? Price { get; set; }

        public Airline? Airline { get; set; }
        public DepartureInfo? DepartureInfo { get; set; }
        public ArrivalInfo? ArrivalInfo { get; set; }
        public List<Seat> Seats { get; set; } = new List<Seat>();
        public List<Booking> Bookings { get; set; } = new List<Booking>();
    }

}
