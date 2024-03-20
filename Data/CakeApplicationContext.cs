using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CakeApplication.Models;

namespace CakeApplication.Data
{
    public class CakeApplicationContext : DbContext
    {
        public CakeApplicationContext (DbContextOptions<CakeApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<CakeApplication.Models.Cakes> Cakes { get; set; } = default!;
    }
}
