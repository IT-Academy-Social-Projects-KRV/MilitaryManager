using MilitaryManager.Core.DTO.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilitaryManager.Core.Interfaces.Services
{
    public interface IEquipmentService
    {
        Task<EntityRequestDTO> CreateEntityAsync(EntityRequestDTO dto);
        Task<EntityRequestDTO> GetEquipmentByIdAsync(int id);
        Task<IEnumerable<EntityRequestDTO>> GetEquipmentAsync();
        Task<EntityRequestDTO> UpdateEntityAsync(EntityRequestDTO dto);
        Task<EntityRequestDTO> DeleteEntityAsync(int id);
    }
}
