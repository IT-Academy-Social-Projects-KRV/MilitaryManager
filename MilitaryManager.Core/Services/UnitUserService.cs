using MilitaryManager.Core.Entities.UnitEntity;
using MilitaryManager.Core.Interfaces.Repositories;
using MilitaryManager.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryManager.Core.Services
{
    public class UnitUserService : IUnitUserService
    {
        protected readonly IRepository<UnitUser, int> _unitUserRepository;

        public async Task<UnitUser> GetUnitUserByKeyAsync(int id)
        {
            return await _unitUserRepository.GetByKeyAsync(id);
        }
    }
}
