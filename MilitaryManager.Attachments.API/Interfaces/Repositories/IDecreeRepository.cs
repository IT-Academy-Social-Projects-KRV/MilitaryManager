using MilitaryManager.Attachments.API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilitaryManager.Attachments.API.Interfaces.Repositories
{
    public interface IDecreeRepository : IBaseRepository<Decree>
    {
        public Task<IEnumerable<Decree>> GetDecreesByName(string name);
    }
}
