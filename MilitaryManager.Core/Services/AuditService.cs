using AutoMapper;
using MilitaryManager.Core.DTO.Audit;
using MilitaryManager.Core.Entities.AuditEntities.ChangeEntity;
using MilitaryManager.Core.Interfaces.Repositories;
using MilitaryManager.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryManager.Core.Services
{
    public class AuditService : IAuditService
    {
        protected readonly IRepository<Change, int> _auditRepository;
        protected readonly IMapper _mapper;

        public AuditService(IRepository<Change, int> auditRepository, IMapper mapper)
        {
            _auditRepository = auditRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ChangeDTO>> GetChangesListAsync()
        {
            var changes = await _auditRepository.GetAllAsync();
            
            return _mapper.Map<IEnumerable<ChangeDTO>>(changes);
        }

        public async Task<ChangeDTO> GetFullChangeInfoByKeyAsync(int id)
        {
            var change = await _auditRepository.GetFirstBySpecAsync(new Changes.ChangeFullInfoById(id));

            return _mapper.Map<ChangeDTO>(change);
        }
    }
}
