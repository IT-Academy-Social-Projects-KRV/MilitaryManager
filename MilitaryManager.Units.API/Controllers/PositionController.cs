using Microsoft.AspNetCore.Mvc;
using MilitaryManager.Core.Interfaces.Services;
using MilitaryManager.Core.Services;
using System.Threading.Tasks;

namespace MilitaryManager.Units.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "Positions")]
    public class PositionController : ControllerBase
    {
        protected readonly IPositionService _positionService;

        public PositionController(IPositionService positionService)
        {
            _positionService = positionService;
        }

        [HttpGet]
        [Route("collection")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _positionService.GetAllPositionsAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetPosition([FromRoute] int id)
        {
            return Ok(await _positionService.GetPositionByIdAsync(id));
        }
    }
}
