using Microsoft.AspNetCore.Mvc;
using MilitaryManager.Core.Interfaces.Services;
using System.Threading.Tasks;

namespace MilitaryManager.Units.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "Attributes")]
    public class AttributeController: ControllerBase
    {
        protected readonly IAttributeService _attributeService;
        public AttributeController(IAttributeService attributeService)
        {
            _attributeService = attributeService;
        }

        [HttpGet]
        [Route("collection")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _attributeService.GetAllAttributesAsync());
        }

    }
}
