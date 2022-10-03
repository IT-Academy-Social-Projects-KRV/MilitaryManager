using Ardalis.Specification;
using AutoMapper;
using MilitaryManager.Core.DTO.Divisions;
using MilitaryManager.Core.Entities.DivisionEntity;
using MilitaryManager.Core.Entities.DivivsionEntity;
using MilitaryManager.Core.Interfaces.Repositories;
using MilitaryManager.Core.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;


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
            Specification<Division> specification = new Divisions.RootDivisionList();
            var divisions = await _divisionRepository.GetListBySpecAsync(specification);

            return _mapper.Map<IEnumerable<DivisionDTO>>(divisions);
        }

        public async Task<IEnumerable<DivisionDTO>> GetDivisionByKeyAsync(int id)
        {
            Specification<Division> specification = new Divisions.DivisionsListById(id);
            var getDivision = await _divisionRepository.GetListBySpecAsync(specification);

            return _mapper.Map<IEnumerable<DivisionDTO>>(getDivision);
        }

        public async Task<DivisionDTO> CreateDivisionAsync(DivisionDTO query)
        {
            var division = _mapper.Map<Division>(query);
            var newDivision = await _divisionRepository.AddAsync(division);
            await _divisionRepository.SaveChangesAcync();

            return _mapper.Map<DivisionDTO>(newDivision);
        }

        public async Task<DivisionDTO> UpdateDivisionAsync(DivisionDTO query)
        {
            var division = _mapper.Map<Division>(query);
            var updateDivision = await _divisionRepository.UpdateAsync(division);
            await _divisionRepository.SaveChangesAcync();

            return _mapper.Map<DivisionDTO>(updateDivision);
        }

        public async Task<DivisionDTO> DeleteDivisionAsync(int id)
        {
            var division = new Division() { Id = id };
            var deleteDivision = await _divisionRepository.DeleteAsync(division);
            await _divisionRepository.SaveChangesAcync();

            return _mapper.Map<DivisionDTO>(deleteDivision);
        }

    }
}
