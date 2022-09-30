using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilitaryManager.Core.DTO.Units;
using MilitaryManager.Core.Interfaces.Services;
using System.Threading.Tasks;

namespace MilitaryManager.Units.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitFullInfoController : ControllerBase
    {
        protected readonly IUnitService _unitServices;

        public UnitFullInfoController(IUnitService unitServices)
        {
            _unitServices = unitServices;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            return Ok(await _unitServices.GetUnitAsync(id));
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
