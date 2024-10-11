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
    public class IndexModel : PageModel
    {
        private readonly FinalProject.Data.ApplicationDbContext _context;

        public IndexModel(FinalProject.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ArrivalInfo> ArrivalInfo { get;set; } = default!;

        public async Task OnGetAsync()
        {
            ArrivalInfo = await _context.ArrivalInfo
                .Include(a => a.Airport).ToListAsync();
        }
    }
}
