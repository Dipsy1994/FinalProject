namespace FinalProject.Models
{
    public class Seat
    {
        public int? SeatID { get; set; }
        public int? FlightID { get; set; }
        public string? SeatNumber { get; set; }
        public string? Class { get; set; }
        public bool? Availability { get; set; }

        public Flight? Flight { get; set; }
        public List<Booking> Bookings { get; set; } = new List<Booking>();
    }

}
