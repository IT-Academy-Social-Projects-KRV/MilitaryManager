using MilitaryManager.Core.DTO.Ranks;
using MilitaryManager.Core.DTO.Units;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryManager.Core.Interfaces.Services
{
    public interface IRankService
    {
        Task<IEnumerable<RankDTO>> GetAllRanksAsync();
        Task<RankDTO> CreateUnitAsync(RankDTO query);
        Task<RankDTO> UpdateUnitAsync(RankDTO query);
        Task<RankDTO> DeleteUnitAsync(int id);
        Task<IEnumerable<RankDTO>> GetUnitsAsync();
        Task<RankDTO> GetUnitsByIdAsync(int id);
    }
}
