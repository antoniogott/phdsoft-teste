using System.Threading.Tasks;
using Server.Models;

namespace Server.Services
{
    public interface IDependentService
    {
        Task<Dependent> GetDependentAsync(int id);
        Task DeleteDependentAsync(int id);
    }
}
