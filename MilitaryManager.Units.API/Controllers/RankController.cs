using Microsoft.AspNetCore.Mvc;
using MilitaryManager.Core.Interfaces.Services;
using MilitaryManager.Core.Services;
using System.Threading.Tasks;

namespace MilitaryManager.Units.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "Ranks")]
    public class RankController : ControllerBase
    {
        protected readonly IRankService _rankService;

        public RankController(IRankService rankService)
        {
            _rankService = rankService;
        }

        [HttpGet]
        [Route("collection")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _rankService.GetAllRanksAsync());
        }
    }
}
