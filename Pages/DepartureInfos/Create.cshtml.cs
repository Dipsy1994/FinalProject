using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FinalProject.Data;
using FinalProject.Models;

namespace FinalProject.Pages.DepartureInfos
{
    public class CreateModel : PageModel
    {
        private readonly FinalProject.Data.ApplicationDbContext _context;

        public CreateModel(FinalProject.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AirportID"] = new SelectList(_context.Airport, "AirportID", "AirportID");
            return Page();
        }

        [BindProperty]
        public DepartureInfo DepartureInfo { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.DepartureInfo.Add(DepartureInfo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
