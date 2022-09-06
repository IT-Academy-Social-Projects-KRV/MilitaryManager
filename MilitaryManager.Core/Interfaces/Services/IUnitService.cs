using MilitaryManager.Core.DTO.Units;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilitaryManager.Core.Interfaces.Services
{
    public interface IUnitService
    {
        Task<IEnumerable<UnitDTO>> GetUnitsTreeAsync();
        Task<IEnumerable<UnitDTO>> GetUnitsAsync();
        Task<UnitDTO> GetUnitByIdAsync(int id);
        Task SaveUnitAsync(UnitDTO query);
        Task UpdateUnitAsync(UnitDTO query);
        Task DeleteUnitAsync(UnitDTO query);
    }
}
