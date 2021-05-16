using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SmartBeauty.Data;
using SmartBeauty.Models;

namespace SmartBeauty.Pages.Salon
{
    public class DetailsModel : PageModel
    {
        private readonly SmartBeauty.Data.ApplicationDbContext _context;

        public DetailsModel(SmartBeauty.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public SmartBeauty.Models.Salon Salon { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Salon = await _context.Salon.FirstOrDefaultAsync(m => m.SalonID == id);

            if (Salon == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
