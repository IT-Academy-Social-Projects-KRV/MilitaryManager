using MilitaryManager.Core.DTO.Units;
using MilitaryManager.Core.Entities.UnitEntity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryManager.Core.Interfaces.Services
{
    public interface IUnitUserService
    {
        Task<UnitUser> GetUnitUserAsync(string id);
        Task<UnitUser> CreateUnitUserAsync(UnitDTO unit);
    }
}
