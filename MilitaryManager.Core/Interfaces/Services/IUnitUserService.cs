using MilitaryManager.Core.Entities.UnitEntity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryManager.Core.Interfaces.Services
{
    public interface IUnitUserService
    {
        Task<UnitUser> GetUnitUserByKeyAsync(int id);
    }
}
