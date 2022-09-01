using MilitaryManager.Attachments.API.Data;
using MilitaryManager.Attachments.API.Entities;
using MilitaryManager.Attachments.API.Interfaces.Repositories;

namespace MilitaryManager.Attachments.API.Repositories
{
    public class StatusHistoryRepository : BaseRepository<StatusHistory>, IStatusHistoryRepository
    {
        public StatusHistoryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
