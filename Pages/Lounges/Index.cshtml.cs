using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FinalProject.Data;
using FinalProject.Models;

namespace FinalProject.Pages.Lounges
{
    public class IndexModel : PageModel
    {
        private readonly FinalProject.Data.ApplicationDbContext _context;

        public IndexModel(FinalProject.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Lounge> Lounge { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Lounge = await _context.Lounge
                .Include(l => l.Airline)
                .Include(l => l.Airport).ToListAsync();
        }
    }
}
