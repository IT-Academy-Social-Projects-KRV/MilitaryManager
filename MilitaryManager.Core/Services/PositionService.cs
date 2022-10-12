using AutoMapper;
using MilitaryManager.Core.DTO.Positions;
using MilitaryManager.Core.DTO.Units;
using MilitaryManager.Core.Entities.PositionEntity;
using MilitaryManager.Core.Entities.UnitEntity;
using MilitaryManager.Core.Interfaces.Repositories;
using MilitaryManager.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryManager.Core.Services
{
    public class PositionService : IPositionService
    {
        protected readonly IRepository<Position, int> _positionRepository;
        protected readonly IMapper _mapper;

        public PositionService(IRepository<Position, int> positionRepository, IMapper mapper)
        {
            _positionRepository = positionRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PositionDTO>> GetAllPositionsAsync()
        {
            var positions = await _positionRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<PositionDTO>>(positions);
        }

        public Task<PositionDTO> CreateUnitAsync(PositionDTO query)
        {
            throw new NotImplementedException();
        }

        public Task<PositionDTO> UpdateUnitAsync(PositionDTO query)
        {
            throw new NotImplementedException();
        }

        public Task<PositionDTO> DeleteUnitAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PositionDTO>> GetUnitsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<PositionDTO> GetUnitsByIdAsync(int id)
        {
            var units = await _positionRepository.GetByKeyAsync(id);

            return _mapper.Map<PositionDTO>(units);
        }
    }
}
