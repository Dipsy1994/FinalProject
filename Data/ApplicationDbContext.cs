using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FinalProject.Models;

namespace FinalProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<FinalProject.Models.Booking> Booking { get; set; } = default!;
        public DbSet<FinalProject.Models.Airline> Airline { get; set; } = default!;
        public DbSet<FinalProject.Models.ArrivalInfo> ArrivalInfo { get; set; } = default!;
        public DbSet<FinalProject.Models.Airport> Airport { get; set; } = default!;
        public DbSet<FinalProject.Models.City> City { get; set; } = default!;
        public DbSet<FinalProject.Models.DepartureInfo> DepartureInfo { get; set; } = default!;
        public DbSet<FinalProject.Models.Flight> Flight { get; set; } = default!;
        public DbSet<FinalProject.Models.Lounge> Lounge { get; set; } = default!;
        public DbSet<FinalProject.Models.Seat> Seat { get; set; } = default!;
        public DbSet<FinalProject.Models.User> User { get; set; } = default!;
    }
}
