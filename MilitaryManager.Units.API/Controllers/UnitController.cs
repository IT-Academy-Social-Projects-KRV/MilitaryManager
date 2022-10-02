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
        [Route("collection")]
        public async Task<IActionResult> GetRootTreeUnit()
        {
            return Ok(await _unitServices.GetUnitsTreeAsync(null));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetTreeNodeUnit([FromRoute] int id)
        {
            return Ok(await _unitServices.GetUnitsTreeAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateUnit([FromBody] UnitDTO query)
        {
            return Ok(await _unitServices.CreateUnitAsync(query));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUnit([FromBody] UnitDTO query)
        {
            return Ok(await _unitServices.UpdateUnitAsync(query));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUnit([FromBody] UnitDTO query)
        {
            return Ok(await _unitServices.DeleteUnitAsync(query.Id));
        }
    }
}
