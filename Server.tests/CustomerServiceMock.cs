using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

using Server.Models;
using Server.Services;
using Server.Controllers;
using System.Threading.Tasks;

namespace Server.tests
{
    public class CustomerServiceMock : ICustomerService
    {
        private readonly List<Customer> _customers;

        public CustomerServiceMock()
        {
            _customers = Helper.GetCustomers();
        }

        public async Task DeleteCustomerAsync(int id)
        {
            _customers.RemoveAll(c => c.Id == id);
        }

        public async Task<Customer> GetCustomerAsync(int id)
        {
            return _customers.FirstOrDefault(c => c.Id == id);
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return _customers;
        }

        public async Task<Customer> CreateCustomer(Customer customer)
        {
            customer.Id = _customers.Max(c => c.Id) + 1;
            _customers.Add(customer);
            return customer;
        }

        public async Task UpdateCustomer(int id, Customer customer)
        {
            var index = _customers.FindIndex(c => c.Id == id);
            _customers[index] = customer;
        }
    }
}