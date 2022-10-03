using MilitaryManager.Core.DTO.Divisions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilitaryManager.Core.Interfaces.Services
{
    public interface IDivisionService
    {
        Task <IEnumerable<DivisionDTO>> GetDivisionByKeyAsync(int id);
        Task<IEnumerable<DivisionDTO>> GetAllDivisionsAsync();
        Task<DivisionDTO> CreateDivisionAsync(DivisionDTO query);
        Task<DivisionDTO> UpdateDivisionAsync(DivisionDTO query);
        Task<DivisionDTO> DeleteDivisionAsync(int id);
    }
}
