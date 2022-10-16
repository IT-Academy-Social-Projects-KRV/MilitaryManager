using MilitaryManager.Core.DTO.Divisions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilitaryManager.Core.Interfaces.Services
{
    public interface IDivisionService
    {
        Task<DivisionDTO> GetDivisionByKeyAsync(int id);
        Task<IEnumerable<DivisionDTO>> GetAllDivisionsAsync();
        Task<DivisionDTO> CreateDivisionAsync(DivisionRequestDTO dto);
        Task<DivisionDTO> UpdateDivisionAsync(DivisionRequestDTO dto);
        Task<DivisionDTO> DeleteDivisionAsync(int id);
    }
}
