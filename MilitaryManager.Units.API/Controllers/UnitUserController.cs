using Microsoft.AspNetCore.Mvc;
using MilitaryManager.Core.Interfaces.Services;
using System.Threading.Tasks;

namespace MilitaryManager.Units.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UnitUserController : Controller
    {
        protected readonly IUnitUserService _unitUserService;

        public UnitUserController(IUnitUserService unitUserService)
        {
            _unitUserService = unitUserService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetUnitUser([FromRoute] int id)
        {
            return Ok(await _unitUserService.GetUnitUserByKeyAsync(id));
        }
    }
}
