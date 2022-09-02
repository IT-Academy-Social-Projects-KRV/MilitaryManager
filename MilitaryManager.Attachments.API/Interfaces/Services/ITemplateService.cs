using MilitaryManager.Attachments.API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilitaryManager.Attachments.API.Interfaces.Services
{
    public interface ITemplateService
    {
        Task<IEnumerable<Template>> GetTemplatesAsync();
        Task<string> GetTemplateDataByIdAsync(int id);
    }
}
