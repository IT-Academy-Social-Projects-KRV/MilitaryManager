using MilitaryManager.Core.Entities.Entity;
using MilitaryManager.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryManager.Core.Services
{
    public class UnitService : IUnitService
    {
        public Task<List<Entity>> GetEntityAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
