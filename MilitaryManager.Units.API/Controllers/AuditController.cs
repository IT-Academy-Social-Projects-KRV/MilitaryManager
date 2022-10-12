using Microsoft.AspNetCore.Mvc;
using MilitaryManager.Core.Interfaces.Services;
using System.Threading.Tasks;

namespace MilitaryManager.Units.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "Audit")]
    public class AuditController : Controller
    {
        protected readonly IAuditService _auditService;

        public AuditController(IAuditService auditService)
        {
            _auditService = auditService;
        }

        [HttpGet]
        [Route("collection")]
        public async Task<IActionResult> GetChangesList()
        {
            return Ok(await _auditService.GetChangesListAsync());
        }

        [HttpGet]
        [Route("collection/{id}")]
        public async Task<IActionResult> GetFullChangeInfo([FromRoute] int id)
        {
            return Ok(await _auditService.GetFullChangeInfoByKeyAsync(id));
        }
    }
}
