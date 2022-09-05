using MilitaryManager.Core.DTO.Units;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilitaryManager.Core.Interfaces.Services
{
    public interface IUnitServices
    {
        Task<IEnumerable<UnitDTO>> GetUnitsTreeAsync();
    }
}
