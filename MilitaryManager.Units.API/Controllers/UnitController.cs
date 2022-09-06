using Microsoft.AspNetCore.Mvc;
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
        protected readonly IMapper _mapper;

        public UnitController(IRepository<Unit> unitRepository, IUnitServices unitServices, IMapper mapper)
        {
            _unitRepository = unitRepository;
            _unitServices = unitServices;
            _mapper = mapper;
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
            var newUnit = new UnitDTO() { Name = "Charles", Address = "Address1", ParentId = 3 };
            var unit = _mapper.Map<Unit>(newUnit);
            await _unitRepository.AddAsync(unit);
            await _unitRepository.SaveChangesAcync();

            return Ok();
        }

        [HttpGet]
        [Route("getUnitBySpecification")]
        public async Task<IEnumerable<UnitDTO>> GetUnitBySpecification()
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
