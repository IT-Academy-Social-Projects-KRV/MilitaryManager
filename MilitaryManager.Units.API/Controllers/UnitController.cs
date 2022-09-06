using Microsoft.AspNetCore.Mvc;
using MilitaryManager.Core.DTO.Units;
using MilitaryManager.Core.Interfaces.Services;
using System.Collections.Generic;
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
        [Route("getunits")]
        public async Task<IEnumerable<UnitDTO>> GetUnits()
        {
            var entities = await _unitServices.GetUnitsAsync();

            return entities;
        }

        [HttpGet]
        [Route("getunitstree")]
        public async Task<IEnumerable<UnitDTO>> GetUnitsTree()
        {
            var entities = await _unitServices.GetUnitsTreeAsync();

            return entities;
        }

        [HttpGet]
        [Route("getunitbyid/{id}")]
        public async Task<UnitDTO> GetUnitById(int id)
        {
            var entity = await _unitServices.GetUnitByIdAsync(id);

            return entity;
        }

        [HttpPost]
        [Route("saveunit")]
        public async Task<IActionResult> SaveUnit([FromBody] UnitDTO query)
        {
            await _unitServices.SaveUnitAsync(query);

            return Ok();
        }

        [HttpPost]
        [Route("updateunit")]
        public async Task<IActionResult> UpdateUnit([FromBody] UnitDTO query)
        {
            await _unitServices.UpdateUnitAsync(query);

            return Ok();
        }

        [HttpPost]
        [Route("deleteunit")]
        public async Task<IActionResult> DeleteUnit([FromBody] UnitDTO query)
        {
            await _unitServices.DeleteUnitAsync(query);

            return Ok();
        }
    }
}
