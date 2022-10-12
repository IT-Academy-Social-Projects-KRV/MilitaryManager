using Microsoft.AspNetCore.Mvc;
using MilitaryManager.Core.DTO.Units;
using MilitaryManager.Core.Interfaces.Services;
using System.Threading.Tasks;

namespace MilitaryManager.Units.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "Units")]
    public class UnitController : ControllerBase
    {
        protected readonly IUnitService _unitServices;

        public UnitController(IUnitService unitServices)
        {
            _unitServices = unitServices;
        }


        [HttpGet]
        [Route("collection")]
        public async Task<IActionResult> GetRootTree()
        {
            return Ok(await _unitServices.GetUnitsTreeAsync(null));
        }

        [HttpGet]
        [Route("collection/{id}")]
        public async Task<IActionResult> GetTreeNode([FromRoute] int id)
        {
            return Ok(await _unitServices.GetUnitsTreeAsync(id));
        }

        [HttpGet]
        [Route("collection/info")]
        public async Task<IActionResult> GetUnits()
        {
            return Ok(await _unitServices.GetUnitsAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetUnit([FromRoute] int id)
        {
            return Ok(await _unitServices.GetUnitsByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UnitDTO query)
        {
            return Ok(await _unitServices.CreateUnitAsync(query));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UnitDTO query)
        {
            return Ok(await _unitServices.UpdateUnitAsync(query));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteUnit([FromRoute] int id)
        {
            return Ok(await _unitServices.DeleteUnitAsync(id));
        }
    }
}
