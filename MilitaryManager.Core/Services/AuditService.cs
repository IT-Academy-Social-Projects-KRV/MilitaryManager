using AutoMapper;
using MilitaryManager.Core.DTO.Audit;
using MilitaryManager.Core.Entities.AuditEntities.ChangeEntity;
using MilitaryManager.Core.Entities.AuditEntities.ChangeValueEntity;
using MilitaryManager.Core.Interfaces.Repositories;
using MilitaryManager.Core.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilitaryManager.Core.Services
{
    public class AuditService : IAuditService
    {
        protected readonly IRepository<Change, int> _changeRepository;
        protected readonly IRepository<ChangeValue, int> _changeValuesRepository;
        protected readonly IMapper _mapper;

        public AuditService(IRepository<Change, int> changeRepository, IRepository<ChangeValue, int> changeValuesRepository, IMapper mapper)
        {
            _changeRepository = changeRepository;
            _mapper = mapper;
            _changeValuesRepository = changeValuesRepository;
        }

        public async Task<IEnumerable<ChangeDTO>> GetChangesListAsync()
        {
            var changes = await _changeRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<ChangeDTO>>(changes);
        }

        public async Task<IEnumerable<ChangeValuesDTO>> GetFullChangeInfoByKeyAsync(int id)
        {
            var change = await _changeValuesRepository.GetListBySpecAsync(new ChangeValues.ChangeFullInfoById(id));

            return _mapper.Map<IEnumerable<ChangeValuesDTO>>(change);
        }
    }
}
