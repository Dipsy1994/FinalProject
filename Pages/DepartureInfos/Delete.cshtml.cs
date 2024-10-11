using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FinalProject.Data;
using FinalProject.Models;

namespace FinalProject.Pages.DepartureInfos
{
    public class DeleteModel : PageModel
    {
        private readonly FinalProject.Data.ApplicationDbContext _context;

        public DeleteModel(FinalProject.Data.ApplicationDbContext context)
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

            var departureinfo = await _context.DepartureInfo.FirstOrDefaultAsync(m => m.DepartureInfoID == id);

            if (departureinfo == null)
            {
                return NotFound();
            }
            else
            {
                DepartureInfo = departureinfo;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departureinfo = await _context.DepartureInfo.FindAsync(id);
            if (departureinfo != null)
            {
                DepartureInfo = departureinfo;
                _context.DepartureInfo.Remove(DepartureInfo);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
