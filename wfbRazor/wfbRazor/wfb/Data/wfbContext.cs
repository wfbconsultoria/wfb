using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using wfb.Models;

namespace wfb.Data
{
    public class wfbContext : DbContext
    {
        public wfbContext (DbContextOptions<wfbContext> options)
            : base(options)
        {
        }

        public DbSet<wfb.Models.ClsUsers> ClsUsers { get; set; } = default!;
    }
}
