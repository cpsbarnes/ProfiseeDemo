using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProfiseeDemo.Models;

namespace ProfiseeDemo.Data
{
    public class ProfiseeDemoContext : DbContext
    {
        public ProfiseeDemoContext (DbContextOptions<ProfiseeDemoContext> options)
            : base(options)
        {
        }

        public DbSet<ProfiseeDemo.Models.SalesPerson> SalesPerson { get; set; } = default!;
       public DbSet<ProfiseeDemo.Models.Customer> Customer{ get; set; } = default!;
        public DbSet<ProfiseeDemo.Models.Product> Product{ get; set; } = default!;
        public DbSet<ProfiseeDemo.Models.Sales> Sales{ get; set; } = default!;
        public DbSet<ProfiseeDemo.Models.Discount> Discount{ get; set; } = default!;



    }
}
