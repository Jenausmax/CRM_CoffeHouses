using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM_Bunny.Core
{
    public class CrmContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<VisitCustomers> VisitCustomers { get; set; }
        public DbSet<KartSale> KartSales { get; set; }

        public CrmContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=BunnyRsk.db");
        }
     }
}
