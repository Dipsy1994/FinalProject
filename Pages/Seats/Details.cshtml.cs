﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FinalProject.Data;
using FinalProject.Models;

namespace FinalProject.Pages.Seats
{
    public class DetailsModel : PageModel
    {
        private readonly FinalProject.Data.ApplicationDbContext _context;

        public DetailsModel(FinalProject.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Seat Seat { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seat = await _context.Seat.FirstOrDefaultAsync(m => m.SeatID == id);
            if (seat == null)
            {
                return NotFound();
            }
            else
            {
                Seat = seat;
            }
            return Page();
        }
    }
}
