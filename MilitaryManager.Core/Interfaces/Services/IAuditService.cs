using MilitaryManager.Core.DTO.Audit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryManager.Core.Interfaces.Services
{
    public interface IAuditService
    {
        Task<IEnumerable<AuditDTO>> GetChangesListAsync();
        Task<AuditDTO> GetFullChangeInfoByKeyAsync(int id);
    }
}
