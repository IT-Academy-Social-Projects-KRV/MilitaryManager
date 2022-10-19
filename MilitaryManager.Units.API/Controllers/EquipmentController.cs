using Microsoft.AspNetCore.Mvc;
using MilitaryManager.Core.DTO.Entities;
using MilitaryManager.Core.DTO.Units;
using MilitaryManager.Core.Interfaces.Services;
using MilitaryManager.Core.Services;
using System.Threading.Tasks;

namespace MilitaryManager.Units.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "Equipment")]
    public class EquipmentController: ControllerBase
    {
        protected readonly IEquipmentService _equipmentService;
        public EquipmentController(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetEquipmentById([FromRoute] int id)
        {
            return Ok(await _equipmentService.GetEquipmentByIdAsync(id));
        }
        [HttpGet]
        [Route("collection")]
        public async Task<IActionResult> GetEquipment()
        {
            return Ok(await _equipmentService.GetEquipmentAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EntityDTO entityDTO)
        {
            return Ok(await _equipmentService.CreateEntityAsync(entityDTO));
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] EntityDTO entityDTO)
        {
            return Ok(await _equipmentService.UpdateEntityAsync(entityDTO));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteEntity([FromRoute] int id)
        {
            return Ok(await _equipmentService.DeleteEntityAsync(id));
        }
    }
}
