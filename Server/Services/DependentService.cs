using System.Threading.Tasks;
using Server.Models;

namespace Server.Services
{
    public class DependentService : IDependentService
    {
        private readonly CustomerContext _context;

        public DependentService(CustomerContext context)
        {
            _context = context;
        }

        public async Task<Dependent> GetDependentAsync(int id)
        {
            var dependent = await _context.Dependents.FindAsync(id);
            return dependent;
        }

        public async Task DeleteDependentAsync(int id)
        {
            var dependent = await _context.Dependents.FindAsync(id);

            _context.Dependents.Remove(dependent);
            await _context.SaveChangesAsync();
        }
    }
}
