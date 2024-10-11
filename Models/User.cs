namespace FinalProject.Models
{
    public class User
    {
        public int? UserID { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Pwd { get; set; }

        public List<Booking>? Bookings { get; set; } = new List<Booking>();
    }

}
