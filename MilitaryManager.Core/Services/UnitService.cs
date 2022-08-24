using AutoMapper;
using MilitaryManager.Core.Entities.Entity;
using MilitaryManager.Core.Interfaces.Repositories;
using MilitaryManager.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryManager.Core.Services
{
    public class UnitService : IUnitService
    {
        protected readonly IRepository<Entity> _entityRepository;

        public UnitService(IRepository<Entity> entityRepository)
        {
            _entityRepository = entityRepository;
        }

        public async Task<List<Entity>> GetEntitiesAsync()
        {
            var entities = await _entityRepository.GetAllAsync();

            return (List<Entity>)entities;
        }
    }
}
