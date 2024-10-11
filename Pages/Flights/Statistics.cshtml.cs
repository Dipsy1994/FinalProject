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

        public async Task OnGetAsync()
        {
            try
            {
                TotalFlights = await _context.Flight.CountAsync();
                TotalUsers = await _context.Users.CountAsync();
            }
            catch (Exception ex)
            {
                // Log the exception
                ModelState.AddModelError(string.Empty, "An error occurred while retrieving flight statistics.");
                Console.WriteLine(ex.Message); // For debugging purposes
            }
        }
    }
}
