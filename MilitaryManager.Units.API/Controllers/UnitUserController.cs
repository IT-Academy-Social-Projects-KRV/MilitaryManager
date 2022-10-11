using Microsoft.AspNetCore.Mvc;
using MilitaryManager.Core.DTO.Units;
using MilitaryManager.Core.Entities.UnitEntity;
using MilitaryManager.Core.Interfaces.Services;
using System.Threading.Tasks;

namespace MilitaryManager.Units.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "UnitUsers")]
    public class UnitUserController : ControllerBase
    {
        protected readonly IUnitUserService _unitUserService;

        public UnitUserController(IUnitUserService unitUserService)
        {
            _unitUserService = unitUserService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetUnitUser([FromRoute] int id)
        {
            return Ok(await _unitUserService.GetUnitUserByKeyAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UnitDTO unit)
        {
            return Ok(await _unitUserService.CreateUnitUserAsync(unit));
        }
    }
}
