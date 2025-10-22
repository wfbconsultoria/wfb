using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using wfb.Data;
using wfb.Models;

namespace wfb.Pages.Users
{
    public class DeleteModel : PageModel
    {
        private readonly wfb.Data.wfbContext _context;

        public DeleteModel(wfb.Data.wfbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ClsUsers ClsUsers { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clsusers = await _context.ClsUsers.FirstOrDefaultAsync(m => m.Id == id);

            if (clsusers == null)
            {
                return NotFound();
            }
            else
            {
                ClsUsers = clsusers;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clsusers = await _context.ClsUsers.FindAsync(id);
            if (clsusers != null)
            {
                ClsUsers = clsusers;
                _context.ClsUsers.Remove(ClsUsers);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
