using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly CustomerContext _context;

        public CustomerService(CustomerContext context)
        {
            _context = context;
        }

        public async Task DeleteCustomerAsync(int id)
        {
            var customer = await _context.Customers
                .Include(c => c.Dependents)
                .FirstOrDefaultAsync(c => c.Id == id);

            _context.Dependents.RemoveRange(customer.Dependents);
            _context.Customers.Remove(customer);

            await _context.SaveChangesAsync();
        }

        public async Task<Customer> GetCustomerAsync(int id)
        {
            var customer = await _context.Customers
                .Include(c => c.Dependents)
                .FirstOrDefaultAsync(c => c.Id == id);

            return customer;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _context.Customers
                .Include(c => c.Dependents)
                .ToListAsync();
        }

        public async Task<Customer> CreateCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return customer;
        }

        public async Task UpdateCustomer(int id, Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
            await UpdateDependents(customer);
            await _context.SaveChangesAsync();
        }


        private async Task UpdateDependents(Customer customer)
        {
            var currentDependents = _context.Dependents.Where(d => d.Customer == customer);
            _context.Dependents.RemoveRange(currentDependents);
            await _context.SaveChangesAsync();

            await _context.Dependents.AddRangeAsync(customer.Dependents);
        }
    }
}
