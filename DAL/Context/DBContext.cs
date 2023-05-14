using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    public class DBContext : DbContext
    {
        public DBContext() { }

        public DBContext(DbContextOptions<DBContext> options) : base(options) { }
        public DbSet<Inventory> inventories { get; set; }

        public DbSet<Supplier> suppliers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"data source=LAPTOP-NSEO6GV0;initial catalog=practiceDb;integrated security=true;
TrustServerCertificate=True");
        }
    }
}
