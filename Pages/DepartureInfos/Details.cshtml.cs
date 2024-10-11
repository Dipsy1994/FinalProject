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
    public class DetailsModel : PageModel
    {
        private readonly FinalProject.Data.ApplicationDbContext _context;

        public DetailsModel(FinalProject.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
