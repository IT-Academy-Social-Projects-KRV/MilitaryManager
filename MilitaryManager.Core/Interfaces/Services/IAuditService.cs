using MilitaryManager.Core.DTO.Audit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilitaryManager.Core.Interfaces.Services
{
    public interface IAuditService
    {
        Task<IEnumerable<ChangeDTO>> GetChangesListAsync();
        Task<IEnumerable<ChangeValuesDTO>> GetFullChangeInfoByKeyAsync(int id);
    }
}
