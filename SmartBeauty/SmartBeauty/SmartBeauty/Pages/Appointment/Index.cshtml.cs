using System;
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
    public class IndexModel : PageModel
    {
        private readonly SmartBeauty.Data.ApplicationDbContext _context;

        public IndexModel(SmartBeauty.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<SmartBeauty.Models.Appointment> Appointment { get;set; }

        public async Task OnGetAsync()
        {
            Appointment = await _context.Appointment
                .Include(a => a.Client)
                .Include(a => a.Salon)
                .Include(a => a.Service)
                .Include(a => a.Staff)
                .Include(a => a.TimeSpot).ToListAsync();
        }
    }
}
