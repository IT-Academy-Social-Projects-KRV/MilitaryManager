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
        Task<PositionDTO> CreatePositionAsync(PositionDTO query);
        Task<PositionDTO> UpdatePositionAsync(PositionDTO query);
        Task<PositionDTO> DeletePositionAsync(int id);
        Task<IEnumerable<PositionDTO>>GetPositionsAsync();
        Task<PositionDTO> GetPositionByIdAsync(int id);

    }
}
