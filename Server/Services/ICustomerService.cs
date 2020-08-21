using System.Collections.Generic;
using System.Threading.Tasks;
using Server.Models;

namespace Server.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer> GetCustomerAsync(int id);
        Task UpdateCustomer(int id, Customer customer);
        Task<Customer> CreateCustomer(Customer customer);
        Task DeleteCustomerAsync(int id);
    }
}
