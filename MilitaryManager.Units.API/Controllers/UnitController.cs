using Microsoft.AspNetCore.Mvc;
using MilitaryManager.Core.Entities.UnitEntity;
using MilitaryManager.Core.Interfaces.Repositories;
using MilitaryManager.Core.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilitaryManager.Units.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UnitController : ControllerBase
    {
        protected readonly IRepository<Unit> _unitRepository;
        protected readonly IUnitServices _unitServices;

        public UnitController(IRepository<Unit> unitRepository, IUnitServices unitServices)
        {
            _unitRepository = unitRepository;
            _unitServices = unitServices;
        }

        [HttpGet]
        [Route("getUnits")]
        public async Task<IEnumerable<Unit>> GetUnits()
        {
            var entities = await _unitRepository.GetAllAsync();

            return entities;
        }

        [HttpPost]
        [Route("saveUnit")]
        public async Task<IActionResult> SaveUnit()
        {
            var newUnit = new Unit() { Name = "Charles", Address = "Address1", ParentId = 3 };
            await _unitRepository.AddAsync(newUnit);
            await _unitRepository.SaveChangesAcync();

            return Ok();
        }

        [HttpGet]
        [Route("getUnitBySpecification")]
        public async Task<IEnumerable<Unit>> GetUnitBySpecification()
        {
            var entities = await _unitServices.GetUnitsTreeAsync();

            return entities;
        }

        [HttpGet]
        [Route("getUnitById")]
        public async Task<Unit> GetUnitById()
        {
            var entities = await _unitRepository.GetByKeyAsync<int>(1);

            return entities;
        }
    }
}
