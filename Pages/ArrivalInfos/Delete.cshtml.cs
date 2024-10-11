using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FinalProject.Data;
using FinalProject.Models;

namespace FinalProject.Pages.ArrivalInfos
{
    public class DeleteModel : PageModel
    {
        private readonly FinalProject.Data.ApplicationDbContext _context;

        public DeleteModel(FinalProject.Data.ApplicationDbContext context)
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

            var arrivalinfo = await _context.ArrivalInfo.FirstOrDefaultAsync(m => m.ArrivalInfoID == id);

            if (arrivalinfo == null)
            {
                return NotFound();
            }
            else
            {
                ArrivalInfo = arrivalinfo;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arrivalinfo = await _context.ArrivalInfo.FindAsync(id);
            if (arrivalinfo != null)
            {
                ArrivalInfo = arrivalinfo;
                _context.ArrivalInfo.Remove(ArrivalInfo);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
