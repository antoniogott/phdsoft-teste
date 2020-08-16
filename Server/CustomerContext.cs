using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server
{
    public class CustomerContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Dependent> Dependents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
         => options.UseSqlite("Data Source=customers.db");
    }
}