using Microsoft.AspNetCore.Mvc;
using MilitaryManager.Core.DTO.Units;
using MilitaryManager.Core.Interfaces.Services;
using System.Threading.Tasks;

namespace MilitaryManager.Units.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UnitController : ControllerBase
    {
        protected readonly IUnitService _unitServices;

        public UnitController(IUnitService unitServices)
        {
            _unitServices = unitServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetTree()
        {
            return Ok(await _unitServices.GetUnitsTreeAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UnitDTO query)
        {
            await _unitServices.CreateUnitAsync(query);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UnitDTO query)
        {
            await _unitServices.UpdateUnitAsync(query);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUnit([FromBody] UnitDTO query)
        {
            await _unitServices.DeleteUnitAsync(query);

            return Ok();
        }
    }
}
