using MilitaryManager.Attachments.API.Data;
using MilitaryManager.Attachments.API.Entities;
using MilitaryManager.Attachments.API.Interfaces.Repositories;

namespace MilitaryManager.Attachments.API.Repositories
{
    public class DecreeRepository : BaseRepository<Decree>, IDecreeRepository
    {
        public DecreeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
