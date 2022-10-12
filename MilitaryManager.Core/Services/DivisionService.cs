using Ardalis.Specification;
using AutoMapper;
using MilitaryManager.Core.DTO.Divisions;
using MilitaryManager.Core.Entities.DivisionEntity;
using MilitaryManager.Core.Entities.DivivsionEntity;
using MilitaryManager.Core.Interfaces.Repositories;
using MilitaryManager.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MilitaryManager.Core.Entities.DivivsionEntity.Divisions;

namespace MilitaryManager.Core.Services
{
    public class DivisionService: IDivisionService
    {
        protected readonly IRepository<Division, int> _divisionRepository;
        protected readonly IMapper _mapper;
        public DivisionService(IRepository<Division, int> divisionRepository, IMapper mapper)
        {
            _divisionRepository = divisionRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<DivisionDTO>> GetAllDivisionsAsync()
        {
            Specification<Division> specification = new Divisions.DivisionsList();
            var divisions = await _divisionRepository.GetListBySpecAsync(specification);
            var getDivisions = divisions.Where(x => x.ParentId == null);

            return _mapper.Map<IEnumerable<DivisionDTO>>(getDivisions);
        }

        public async Task<IEnumerable<DivisionDTO>> GetAllDivisionsListAsync()
        {
            var divisions = await _divisionRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<DivisionDTO>>(divisions);
        }

        public async Task<DivisionDTO> GetDivisionByKeyAsync(int id)
        {
            Specification<Division> specification = new Divisions.DivisionById(id);
            var division = await _divisionRepository.GetFirstBySpecAsync(specification);

            return _mapper.Map<DivisionDTO>(division);
        }

        public async Task<DivisionDTO> CreateDivisionAsync(DivisionDTO dto)
        {
            var division = _mapper.Map<Division>(dto);
            var newDivision = await _divisionRepository.AddAsync(division);
            await _divisionRepository.SaveChangesAcync();

            return _mapper.Map<DivisionDTO>(newDivision);
        }

        public async Task<DivisionDTO> UpdateDivisionAsync(DivisionDTO dto)
        {
            var division = _mapper.Map<Division>(dto);
            var updateDivision = await _divisionRepository.UpdateAsync(division);
            await _divisionRepository.SaveChangesAcync();

            return _mapper.Map<DivisionDTO>(updateDivision);
        }

        public async Task<DivisionDTO> DeleteDivisionAsync(int id)
        {
            var foundDivision = await _divisionRepository.GetByKeyAsync(id);

            if (foundDivision == null)
            {
                throw new ArgumentException("Division not found");
            }

            var deleteDivision = await _divisionRepository.DeleteAsync(foundDivision);
            await _divisionRepository.SaveChangesAcync();

            return _mapper.Map<DivisionDTO>(deleteDivision);
        }
    }
}
