using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SmartBeauty.Data;
using SmartBeauty.Models;

namespace SmartBeauty.Pages.Appointment
{
    public class CreateModel : PageModel
    {
        private readonly SmartBeauty.Data.ApplicationDbContext _context;

        public CreateModel(SmartBeauty.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ClientID"] = new SelectList(_context.Client, "ClientID", "ClientID");
        ViewData["SalonID"] = new SelectList(_context.Salon, "SalonID", "SalonID");
        ViewData["ServiceID"] = new SelectList(_context.Service, "ServiceID", "ServiceID");
        ViewData["StaffID"] = new SelectList(_context.Staff, "StaffID", "StaffID");
        ViewData["TimeSpotID"] = new SelectList(_context.TimeSpot, "TimeSpotID", "TimeSpotID");
            return Page();
        }

        [BindProperty]
        public SmartBeauty.Models.Appointment Appointment { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Appointment.Add(Appointment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
