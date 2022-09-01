using MilitaryManager.Attachments.API.Data;
using MilitaryManager.Attachments.API.Entities;
using MilitaryManager.Attachments.API.Interfaces.Repositories;

namespace MilitaryManager.Attachments.API.Repositories
{
    public class TemplateRepository : BaseRepository<Template>, ITemplateRepository
    {
        public TemplateRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
