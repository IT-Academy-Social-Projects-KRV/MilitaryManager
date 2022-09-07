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
        [Route("get")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _unitServices.GetUnitsAsync());
        }

        [HttpGet]
        [Route("gettree")]
        public async Task<IActionResult> GetTree()
        {
            return Ok(await _unitServices.GetUnitsTreeAsync());
        }

        [HttpGet]
        [Route("getbyid/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _unitServices.GetUnitByIdAsync(id));
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] UnitDTO query)
        {
            await _unitServices.CreateUnitAsync(query);

            return Ok();
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] UnitDTO query)
        {
            await _unitServices.UpdateUnitAsync(query);

            return Ok();
        }

        [HttpPost]
        [Route("delete")]
        public async Task<IActionResult> DeleteUnit([FromBody] UnitDTO query)
        {
            await _unitServices.DeleteUnitAsync(query);

            return Ok();
        }
    }
}
