using Ardalis.Specification;
using AutoMapper;
using MilitaryManager.Core.DTO.Units;
using MilitaryManager.Core.Entities.EntityEntity;
using MilitaryManager.Core.Entities.EntityToAttributeEntity;
using MilitaryManager.Core.Entities.UnitEntity;
using MilitaryManager.Core.Interfaces.Repositories;
using MilitaryManager.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilitaryManager.Core.Services
{
    public class UnitService : IUnitService
    {
        protected readonly IRepository<Unit, int> _unitRepository;
        protected readonly IRepository<Entities.ProfileEntity.Profile, int> _profileRepository;
        protected readonly IMapper _mapper;

        public UnitService(IRepository<Unit, int> unitRepository, IRepository<Entities.ProfileEntity.Profile, int> profileRepository,  IMapper mapper)
        {
            _unitRepository = unitRepository;
            _mapper = mapper;
            _profileRepository = profileRepository; 
        }

        public async Task<IEnumerable<UnitDTO>> GetUnitsTreeAsync(int? id)
        {
            Specification<Unit> specification;

            if (id.HasValue)
            {
                specification = new Units.UnitsListByParentId(id.Value);
            }
            else
            {
                specification = new Units.RootUnitsList();
            }

            var unitsTree = await _unitRepository.GetListBySpecAsync(specification);

            return _mapper.Map<IEnumerable<UnitDTO>>(unitsTree);
        }

        public async Task<UnitDTO> GetUnitAsync(int id)
        {

            var unit = await _unitRepository.GetByKeyAsync(id);

            return _mapper.Map<UnitDTO>(unit);
        }

        public async Task<IEnumerable<UnitDTO>> GetUnitsAsync()
        {
            var units = await _unitRepository.GetListBySpecAsync(new Units.UnitsList());

            return _mapper.Map<IEnumerable<UnitDTO>>(units);
        }
        public async Task<UnitDTO> GetUnitsByIdAsync(int id)
        {
            var units = await _unitRepository.GetFirstBySpecAsync(new Units.UnitById(id));

            return _mapper.Map<UnitDTO>(units);
        }
        public async Task<UnitDTO> CreateUnitAsync(UnitRequestDTO dto)
        {
            var unit = _mapper.Map<Unit>(dto);
            var newUnit = await _unitRepository.AddAsync(unit);
            await _unitRepository.SaveChangesAcync();

            return _mapper.Map<UnitDTO>(newUnit);
        }

        public async Task<UnitDTO> UpdateUnitAsync(UnitRequestDTO query)
        {
            var unit = _mapper.Map<Unit>(query);
            foreach(var value in query.Profiles)
            {
                var profile = _mapper.Map<Entities.ProfileEntity.Profile>(value);
                await _profileRepository.UpdateAsync(profile);
                await _unitRepository.SaveChangesAcync();
            }
            var updateUnit = await _unitRepository.UpdateAsync(unit);
            await _unitRepository.SaveChangesAcync();

            return _mapper.Map<UnitDTO>(updateUnit);
        }

        public async Task<UnitDTO> DeleteUnitAsync(int id)
        {
            var unit = await _unitRepository.GetByKeyAsync(id);
            if (unit == null)
            {
                throw new ArgumentException("Unit not found");
            }
            var deleteUnit = await _unitRepository.DeleteAsync(unit);
            await _unitRepository.SaveChangesAcync();

            return _mapper.Map<UnitDTO>(deleteUnit);
        }
    }
}
