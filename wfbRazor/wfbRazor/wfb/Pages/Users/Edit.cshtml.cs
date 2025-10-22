using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using wfb.Data;
using wfb.Models;

namespace wfb.Pages.Users
{
    public class EditModel : PageModel
    {
        private readonly wfb.Data.wfbContext _context;

        public EditModel(wfb.Data.wfbContext context)
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

            var clsusers =  await _context.ClsUsers.FirstOrDefaultAsync(m => m.Id == id);
            if (clsusers == null)
            {
                return NotFound();
            }
            ClsUsers = clsusers;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ClsUsers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClsUsersExists(ClsUsers.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ClsUsersExists(int id)
        {
            return _context.ClsUsers.Any(e => e.Id == id);
        }
    }
}
