using Microsoft.AspNetCore.Mvc;
using MilitaryManager.Core.Interfaces.Services;
using System.Threading.Tasks;

namespace MilitaryManager.Units.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "UnitsInfo")]
    public class UnitInfoController : Controller
    {
        protected readonly IUnitService _unitServices;

        public UnitInfoController(IUnitService unitServices)
        {
            _unitServices = unitServices;
        }

        [HttpGet]
        [Route("collection")]
        public async Task<IActionResult> GetUnits()
        {
            return Ok(await _unitServices.GetUnitsAsync());
        }
    }
}
