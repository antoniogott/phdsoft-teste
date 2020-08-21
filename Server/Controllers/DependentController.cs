using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.Services;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DependentController : ControllerBase
    {
        IDependentService _service;

        public DependentController(IDependentService service)
        {
            _service = service;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Dependent>> DeleteDependent(int id)
        {
            var dependent = await _service.GetDependentAsync(id);
            if (dependent == null)
            {
                return NotFound();
            }

            await _service.DeleteDependentAsync(id);

            return dependent;
        }
    }
}
