using MilitaryManager.Core.DTO.Audit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryManager.Core.Interfaces.Services
{
    public interface IAuditService
    {
        Task<IEnumerable<ChangeDTO>> GetChangesListAsync();
        Task<ChangeDTO> GetFullChangeInfoByKeyAsync(int id);
    }
}
