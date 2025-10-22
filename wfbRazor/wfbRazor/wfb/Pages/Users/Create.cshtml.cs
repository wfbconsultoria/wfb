using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using wfb.Data;
using wfb.Models;

namespace wfb.Pages.Users
{
    public class CreateModel : PageModel
    {
        private readonly wfb.Data.wfbContext _context;

        public CreateModel(wfb.Data.wfbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ClsUsers ClsUsers { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ClsUsers.Add(ClsUsers);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
