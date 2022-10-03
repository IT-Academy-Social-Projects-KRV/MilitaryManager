using Microsoft.AspNetCore.Mvc;
using MilitaryManager.Core.DTO.Divisions;
using MilitaryManager.Core.Interfaces.Services;
using System.Threading.Tasks;

namespace MilitaryManager.Units.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DivisionController : ControllerBase
    {
        protected readonly IDivisionService _divisionService;

        public DivisionController(IDivisionService divisionService)
        {
            _divisionService = divisionService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _divisionService.GetAllDivisionsAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetDivision([FromRoute] int id)
        {
            return Ok(await _divisionService.GetDivisionByKeyAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateDivision([FromBody] DivisionDTO query)
        {
            return Ok(await _divisionService.CreateDivisionAsync(query));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDivision([FromBody] DivisionDTO query)
        {
            return Ok(await _divisionService.UpdateDivisionAsync(query));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteDivision([FromRoute] int id)
        {
            return Ok(await _divisionService.DeleteDivisionAsync(id));
        }
    }
}
