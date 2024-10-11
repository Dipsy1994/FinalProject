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

namespace FinalProject.Pages.ArrivalInfos
{
    public class EditModel : PageModel
    {
        private readonly FinalProject.Data.ApplicationDbContext _context;

        public EditModel(FinalProject.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ArrivalInfo ArrivalInfo { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arrivalinfo =  await _context.ArrivalInfo.FirstOrDefaultAsync(m => m.ArrivalInfoID == id);
            if (arrivalinfo == null)
            {
                return NotFound();
            }
            ArrivalInfo = arrivalinfo;
           ViewData["AirportID"] = new SelectList(_context.Set<Airport>(), "AirportID", "AirportID");
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

            _context.Attach(ArrivalInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArrivalInfoExists(ArrivalInfo.ArrivalInfoID))
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

        private bool ArrivalInfoExists(int? id)
        {
            return _context.ArrivalInfo.Any(e => e.ArrivalInfoID == id);
        }
    }
}
