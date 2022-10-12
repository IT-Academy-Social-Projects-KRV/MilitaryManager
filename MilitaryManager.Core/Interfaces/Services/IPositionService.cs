using MilitaryManager.Core.DTO.Positions;
using MilitaryManager.Core.DTO.Units;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryManager.Core.Interfaces.Services
{
    public interface IPositionService
    {
        Task<IEnumerable<PositionDTO>> GetAllPositionsAsync();
        Task<PositionDTO> CreateUnitAsync(PositionDTO query);
        Task<PositionDTO> UpdateUnitAsync(PositionDTO query);
        Task<PositionDTO> DeleteUnitAsync(int id);
        Task<IEnumerable<PositionDTO>> GetUnitsAsync();
        Task<PositionDTO> GetUnitsByIdAsync(int id);

    }
}
