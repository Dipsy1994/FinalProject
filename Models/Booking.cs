namespace FinalProject.Models
{
    public class Booking
    {
        public int? BookingID { get; set; }
        public int? UserID { get; set; }
        public int? FlightID { get; set; }
        public int? SeatID { get; set; }
        public DateTime? BookingDate { get; set; }

        public User? User { get; set; }
        public Flight? Flight { get; set; }
        public Seat? Seat { get; set; }
    }

}
