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
    public class DetailsModel : PageModel
    {
        private readonly FinalProject.Data.ApplicationDbContext _context;

        public DetailsModel(FinalProject.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
