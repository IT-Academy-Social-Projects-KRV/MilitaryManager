using Microsoft.AspNetCore.Mvc;
using MilitaryManager.Core.Entities.UnitEntity;
using MilitaryManager.Core.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilitaryManager.Units.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UnitController : ControllerBase
    {
        protected readonly IRepository<Unit> _unitRepository;

        public UnitController(IRepository<Unit> unitRepository)
        {
            _unitRepository = unitRepository;
        }

        [HttpGet]
        [Route("getUnits")]
        public async Task<IEnumerable<Unit>> GetUnits()
        {
            //var specification = new Core.Entities.Entity.Units.UnitsList();
            var entities = await _unitRepository.GetAllAsync();

            return entities.ToList();
        }
    }
}
