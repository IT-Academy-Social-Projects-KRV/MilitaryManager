using MilitaryManager.Core.DTO.Units;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilitaryManager.Core.Interfaces.Services
{
    public interface IUnitService
    {
        Task<IEnumerable<UnitDTO>> GetUnitsTreeAsync(int? id = null);
        Task<UnitDTO> CreateUnitAsync(UnitDTO query);
        Task<UnitDTO> UpdateUnitAsync(UnitDTO query);
        Task<UnitDTO> DeleteUnitAsync(UnitDTO query);
    }
}
