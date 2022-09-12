﻿using AutoMapper;
using MilitaryManager.Core.DTO.Units;
using MilitaryManager.Core.Entities.UnitEntity;
using MilitaryManager.Core.Interfaces.Repositories;
using MilitaryManager.Core.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilitaryManager.Core.Services
{
    public class UnitService : IUnitService
    {
        protected readonly IRepository<Unit, int> _unitRepository;
        protected readonly IMapper _mapper;

        public UnitService(IRepository<Unit, int> unitRepository, IMapper mapper)
        {
            _unitRepository = unitRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UnitDTO>> GetUnitsTreeAsync()
        {
            var specificationUnits = new Units.UnitsList();
            var unitList = await _unitRepository.GetListBySpecAsync(specificationUnits);
            var unitsTree = unitList.Where(x => x.ParentId == null);

            return _mapper.Map<IEnumerable<UnitDTO>>(unitsTree);
        }

        public async Task CreateUnitAsync(UnitDTO query)
        {
            var unit = _mapper.Map<Unit>(query);
            await _unitRepository.AddAsync(unit);
            await _unitRepository.SaveChangesAcync();
        }

        public async Task UpdateUnitAsync(UnitDTO query)
        {
            var unit = _mapper.Map<Unit>(query);
            await _unitRepository.UpdateAsync(unit);
            await _unitRepository.SaveChangesAcync();
        }

        public async Task DeleteUnitAsync(UnitDTO query)
        {
            var unit = _mapper.Map<Unit>(query);
            await _unitRepository.DeleteAsync(unit);
            await _unitRepository.SaveChangesAcync();
        }
    }
}