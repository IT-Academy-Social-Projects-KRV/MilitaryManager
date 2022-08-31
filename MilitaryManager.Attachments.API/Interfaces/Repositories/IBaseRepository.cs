using MilitaryManager.Attachments.API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilitaryManager.Attachments.API.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task Create(TEntity item);
        Task<TEntity> FindById(int id);
        Task<IEnumerable<TEntity>> Get();
        Task Remove(int id);
        Task Update(TEntity item);
    }
}
