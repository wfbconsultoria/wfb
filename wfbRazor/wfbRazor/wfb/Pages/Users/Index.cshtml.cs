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
    public class IndexModel : PageModel
    {
        private readonly wfb.Data.wfbContext _context;

        public IndexModel(wfb.Data.wfbContext context)
        {
            _context = context;
        }

        public IList<ClsUsers> ClsUsers { get;set; } = default!;

        public async Task OnGetAsync()
        {
            ClsUsers = await _context.ClsUsers.ToListAsync();
        }
    }
}
