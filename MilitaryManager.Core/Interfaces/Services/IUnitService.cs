using MilitaryManager.Core.DTO.Units;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilitaryManager.Core.Interfaces.Services
{
    public interface IUnitService
    {
        Task<IEnumerable<UnitDTO>> GetUnitsTreeAsync(int? id);
        Task<UnitDTO> CreateUnitAsync(UnitRequestDTO query);
        Task<UnitDTO> UpdateUnitAsync(UnitRequestDTO query);
        Task<UnitDTO> DeleteUnitAsync(int id);
        Task<IEnumerable<UnitDTO>> GetUnitsAsync();
        Task<UnitDTO> GetUnitsByIdAsync(int id);

        Task<UnitDTO> GetUnitAsync(int id);
    }
}
