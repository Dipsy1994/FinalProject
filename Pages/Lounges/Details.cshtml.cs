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
    public class DetailsModel : PageModel
    {
        private readonly FinalProject.Data.ApplicationDbContext _context;

        public DetailsModel(FinalProject.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Lounge Lounge { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lounge = await _context.Lounge.FirstOrDefaultAsync(m => m.LoungeID == id);
            if (lounge == null)
            {
                return NotFound();
            }
            else
            {
                Lounge = lounge;
            }
            return Page();
        }
    }
}
