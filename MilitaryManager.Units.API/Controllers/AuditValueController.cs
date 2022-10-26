using Microsoft.AspNetCore.Mvc;
using MilitaryManager.Core.Interfaces.Services;
using System.Threading.Tasks;

namespace MilitaryManager.Units.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "Audit")]
    public class AuditValueController : Controller
    {
        protected readonly IAuditService _auditService;

        public AuditValueController(IAuditService auditService)
        {
            _auditService = auditService;
        }

        [HttpGet]
        [Route("collection")]
        public async Task<IActionResult> GetChangesList()
        {
            return Ok(await _auditService.GetChangesListAsync());
        }
    }
}
