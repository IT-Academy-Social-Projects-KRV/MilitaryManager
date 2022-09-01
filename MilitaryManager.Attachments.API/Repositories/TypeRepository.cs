using MilitaryManager.Attachments.API.Data;
using MilitaryManager.Attachments.API.Entities;
using MilitaryManager.Attachments.API.Interfaces.Repositories;

namespace MilitaryManager.Attachments.API.Repositories
{
    public class TypeRepository : BaseRepository<Type>, ITypeRepository
    {
        public TypeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
