using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using MilitaryManager.Core.Entities.Entity;

namespace MilitaryManager.Units.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestBDController
    {
        [HttpGet]
        public IEnumerable<Entity> Get()
        {
            return new List<Entity>();
        }
    }
}
