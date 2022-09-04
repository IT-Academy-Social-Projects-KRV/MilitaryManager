using MilitaryManager.Core.Entities.UnitEntity;
using MilitaryManager.Core.Interfaces.Repositories;
using MilitaryManager.Core.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilitaryManager.Core.Services
{
    public class UnitServices : IUnitServices
    {
        protected readonly IRepository<Unit> _unitRepository;

        public UnitServices(IRepository<Unit> unitRepository)
        {
            _unitRepository = unitRepository;
        }

        public async Task<IEnumerable<Unit>> GetUnitsTreeAsync()
        {
            var specificationUnits = new Units.UnitsList();
            return await _unitRepository.GetListBySpecAsync(specificationUnits);
        }
    }
}
