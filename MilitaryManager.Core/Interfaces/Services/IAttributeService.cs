using MilitaryManager.Core.DTO.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryManager.Core.Interfaces.Services
{
    public interface IAttributeService
    {
        Task<IEnumerable<AttributeDTO>> GetAllAttributesAsync();
        Task<IEnumerable<string>> GetAttributeValuesByKeyAsync(int id);
    }
}
