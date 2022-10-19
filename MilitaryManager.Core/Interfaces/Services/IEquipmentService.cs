using MilitaryManager.Core.DTO.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilitaryManager.Core.Interfaces.Services
{
    public interface IEquipmentService
    {
        Task<EntityDTO> CreateEntityAsync(EntityDTO dto);
        Task<EntityDTO> GetEquipmentByIdAsync(int id);
        Task<IEnumerable<EntityDTO>> GetEquipmentAsync();
        Task<EntityDTO> UpdateEntityAsync(EntityDTO dto);
        Task<EntityDTO> DeleteEntityAsync(int id);
    }
}
