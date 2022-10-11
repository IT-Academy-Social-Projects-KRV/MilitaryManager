using MilitaryManager.Core.DTO.Positions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryManager.Core.Interfaces.Services
{
    public interface IPositionService
    {
        Task<IEnumerable<PositionDTO>> GetAllPositionsAsync();
    }
}
