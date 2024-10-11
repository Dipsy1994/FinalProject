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
    public class SearchModel : PageModel
    {
        private readonly FinalProject.Data.ApplicationDbContext _context;

        public SearchModel(FinalProject.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Lounge> Lounge { get; set; } = default!;

        public bool SearchCompleted { get; set; }

        public String Query { get; set; }

        public async Task OnGetAsync(string query)
        {
            Query = query;
            if (!string.IsNullOrWhiteSpace(query))
            {
                SearchCompleted = true;
                Lounge = await _context.Lounge.Where(x => x.Name.StartsWith(query)).ToListAsync();
            }
            else
            {
                SearchCompleted = false;
                Lounge = new List<Lounge>();
            }

        }
    }
}
