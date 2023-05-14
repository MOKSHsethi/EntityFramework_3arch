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
                @"data source=DESKTOP-REN012L\SQLEXPRESS;initial catalog=empDb;integrated security=true;
TrustServerCertificate=True");
        }
    }
}
