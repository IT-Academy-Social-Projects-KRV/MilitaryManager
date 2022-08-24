using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using MilitaryManager.Core.Entities.Entity;
using MilitaryManager.Core.Interfaces.Services;
using System.Threading.Tasks;

namespace MilitaryManager.Units.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestBDController : ControllerBase
    {
        private readonly IUnitService _unitService;

        public TestBDController(IUnitService unitService)
        {
            _unitService = unitService;
        }

        [HttpGet]
        public async Task<IEnumerable<Entity>> GetEntitiesAsync()
        {
            var entities = await _unitService.GetEntitiesAsync();

            return entities;
        }
    }
}
