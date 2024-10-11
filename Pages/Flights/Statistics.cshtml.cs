using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FinalProject.Data;
using FinalProject.Models;

namespace FinalProject.Pages.Flights
{
    public class StatisticsModel : PageModel
    {
        private readonly FinalProject.Data.ApplicationDbContext _context;

        public StatisticsModel(FinalProject.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Flight Flight { get; set; } = default!;

        public int TotalFlights { get; set; }
        public int TotalUsers { get; set; }
        public int TotalBookings { get; set; }
        public int TotalAirports { get; set; }
        public int TotalCities  { get; set; }
        public int TotalLounges { get; set; }
        public int TotalSeats { get; set; }



        public async Task OnGetAsync()
        {
            try
            {
                TotalFlights = await _context.Flight.CountAsync();
                TotalUsers = await _context.User.CountAsync();
                TotalBookings = await _context.Booking.CountAsync();
                TotalAirports = await _context.Airport.CountAsync();
                TotalCities = await _context.City.CountAsync();
                TotalLounges = await _context.Lounge.CountAsync();
                TotalSeats = await _context.Seat.CountAsync();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while retrieving flight statistics.");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
