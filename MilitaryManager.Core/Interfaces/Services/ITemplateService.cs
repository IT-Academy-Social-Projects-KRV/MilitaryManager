using MilitaryManager.Core.DTO.Attachments;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilitaryManager.Core.Interfaces.Services
{
    public interface ITemplateService
    {
        Task<IEnumerable<TemplateDTO>> GetTemplatesAsync();
    }
}
