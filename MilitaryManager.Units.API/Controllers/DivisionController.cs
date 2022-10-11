using Microsoft.AspNetCore.Mvc;
using MilitaryManager.Core.DTO.Divisions;
using MilitaryManager.Core.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace MilitaryManager.Units.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "Divisions")]
    public class DivisionController : ControllerBase
    {
        protected readonly IDivisionService _divisionService;

        public DivisionController(IDivisionService divisionService)
        {
            _divisionService = divisionService;
        }

        [HttpGet]
        [Route("collection")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _divisionService.GetAllDivisionsAsync());
        }

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> GetAllDivisions()
        {
            return Ok(await _divisionService.GetAllDivisionsListAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetDivision([FromRoute] int id)
        {
            return Ok(await _divisionService.GetDivisionByKeyAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateDivision([FromBody] DivisionDTO dto)
        {
            return Ok(await _divisionService.CreateDivisionAsync(dto));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDivision([FromBody] DivisionDTO dto)
        {
            return Ok(await _divisionService.UpdateDivisionAsync(dto));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteDivision([FromRoute] int id)
        {
            try
            {
               var deleteDivision = await _divisionService.DeleteDivisionAsync(id);

               return Ok(deleteDivision);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
