using Microsoft.AspNetCore.Mvc;
using MilitaryManager.Core.Interfaces.Services;
using System.Threading.Tasks;

namespace MilitaryManager.Units.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AuditValueDetalesController : Controller
    {
        protected readonly IAuditService _auditService;

        public AuditValueDetalesController(IAuditService auditService)
        {
            _auditService = auditService;
        }

        [HttpGet]
        [Route("collection/{id}")]
        public async Task<IActionResult> GetFullChangeInfo([FromRoute] int id)
        {
            return Ok(await _auditService.GetFullChangeInfoByKeyAsync(id));
        }
    }
}
