﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SmartBeauty.Data;
using SmartBeauty.Models;

namespace SmartBeauty.Pages.Appointment
{
    public class DetailsModel : PageModel
    {
        private readonly SmartBeauty.Data.ApplicationDbContext _context;

        public DetailsModel(SmartBeauty.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public SmartBeauty.Models.Appointment Appointment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Appointment = await _context.Appointment
                .Include(a => a.Client)
                .Include(a => a.Salon)
                .Include(a => a.Service)
                .Include(a => a.Staff)
                .Include(a => a.TimeSpot).FirstOrDefaultAsync(m => m.AppointmentID == id);

            if (Appointment == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
