using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SmartBeauty.Data;
using SmartBeauty.Models;
using System.Security.Claims;

namespace SmartBeauty.Pages.Salon
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
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId != "ec0c0a43-bcfb-41e9-a046-3fb0a8c4fac0")
            {
                return Redirect("~/Identity/Account/Login");
            }

            return Page();
        }

        [BindProperty]
        public SmartBeauty.Models.Salon Salon { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var emptySalon = new SmartBeauty.Models.Salon();

            if (await TryUpdateModelAsync<SmartBeauty.Models.Salon>(
                emptySalon,
                "salon",// Prefix for form value.
                s => s.SalonID, s => s.UserName, s => s.SalonName, s => s.Email, s => s.Address, s => s.PhoneNumber, s => s.IdentityID))

                _context.Salon.Add(Salon);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
