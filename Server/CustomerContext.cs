using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server
{
    public class CustomerContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options) {
            options.UseSqlite("Data Source=customers.db");
        }
        
        protected override void OnModelCreating(ModelBuilder builder) {
            builder
                .Entity<Person>()
                .HasAlternateKey(p => p.Cpf);
        }

        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
        {
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Dependent> Dependents { get; set; }
    }
}