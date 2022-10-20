using MilitaryManager.Core.DTO.Ranks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryManager.Core.Interfaces.Services
{
    public interface IRankService
    {
        Task<IEnumerable<RankDTO>> GetAllRanksAsync();
    }
}
