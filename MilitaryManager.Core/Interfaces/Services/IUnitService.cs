﻿using MilitaryManager.Core.DTO.Entities;
using MilitaryManager.Core.DTO.Units;
using MilitaryManager.Core.Entities.UnitEntity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilitaryManager.Core.Interfaces.Services
{
    public interface IUnitService
    {
        Task<IEnumerable<UnitDTO>> GetUnitsTreeAsync(int? id);
        Task<UnitDTO> CreateUnitAsync(UnitDTO query);
        Task<UnitDTO> UpdateUnitAsync(UnitDTO query);
        Task<UnitDTO> DeleteUnitAsync(int id);
        Task<IEnumerable<UnitDTO>> GetUnitsAsync();
        Task<UnitDTO> GetUnitsByIdAsync(int id);
    }
}
