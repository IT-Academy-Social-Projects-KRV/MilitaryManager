using MilitaryManager.Core.Entities.UnitEntity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilitaryManager.Core.Interfaces.Services
{
    public interface IUnitServices
    {
        Task<IEnumerable<Unit>> GetUnitsTreeAsync();
    }
}
