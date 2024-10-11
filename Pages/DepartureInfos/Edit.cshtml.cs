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

namespace FinalProject.Pages.DepartureInfos
{
    public class EditModel : PageModel
    {
        private readonly FinalProject.Data.ApplicationDbContext _context;

        public EditModel(FinalProject.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DepartureInfo DepartureInfo { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departureinfo =  await _context.DepartureInfo.FirstOrDefaultAsync(m => m.DepartureInfoID == id);
            if (departureinfo == null)
            {
                return NotFound();
            }
            DepartureInfo = departureinfo;
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

            _context.Attach(DepartureInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartureInfoExists(DepartureInfo.DepartureInfoID))
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

        private bool DepartureInfoExists(int? id)
        {
            return _context.DepartureInfo.Any(e => e.DepartureInfoID == id);
        }
    }
}
