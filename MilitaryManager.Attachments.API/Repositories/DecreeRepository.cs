using Microsoft.EntityFrameworkCore;
using MilitaryManager.Attachments.API.Data;
using MilitaryManager.Attachments.API.Entities;
using MilitaryManager.Attachments.API.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilitaryManager.Attachments.API.Repositories
{
    public class DecreeRepository : BaseRepository<Decree>, IDecreeRepository
    {
        public DecreeRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Decree>> GetDecreesByName(string name)
        {
            return await _dbSet.Where(d => d.Name.Contains(name)).ToListAsync();
        }
    }
}
