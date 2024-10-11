using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalProject.Data;
using FinalProject.Models;

namespace FinalProject.Pages.Lounges
{
    public class EditModel : PageModel
    {
        private readonly FinalProject.Data.ApplicationDbContext _context;

        public EditModel(FinalProject.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Lounge Lounge { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lounge =  await _context.Lounge.FirstOrDefaultAsync(m => m.LoungeID == id);
            if (lounge == null)
            {
                return NotFound();
            }
            Lounge = lounge;
           ViewData["AirlineID"] = new SelectList(_context.Airline, "AirlineID", "AirlineID");
           ViewData["AirportID"] = new SelectList(_context.Airport, "AirportID", "AirportID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Lounge).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoungeExists(Lounge.LoungeID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool LoungeExists(int? id)
        {
            return _context.Lounge.Any(e => e.LoungeID == id);
        }
    }
}
