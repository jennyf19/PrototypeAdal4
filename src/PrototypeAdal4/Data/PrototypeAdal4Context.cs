using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PrototypeAdal4.Models;

namespace PrototypeAdal4.Data
{
    public class PrototypeAdal4Context : DbContext
    {
        public PrototypeAdal4Context(DbContextOptions<PrototypeAdal4Context> options) : base(options)
        {
        }

        public DbSet<Release> Releases { get; set; }

        public DbSet<Approval> Approvals { get; set; }

        public DbSet<Product> Products { get; set; }

        
    }
}
