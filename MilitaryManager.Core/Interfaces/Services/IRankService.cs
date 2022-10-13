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
        Task<RankDTO> CreateRankAsync(RankDTO query);
        Task<RankDTO> UpdateRankAsync(RankDTO query);
        Task<RankDTO> DeleteRankAsync(int id);
        Task<IEnumerable<RankDTO>> GetUnitsAsync();
        Task<RankDTO> GetRankByIdAsync(int id);
    }
}
