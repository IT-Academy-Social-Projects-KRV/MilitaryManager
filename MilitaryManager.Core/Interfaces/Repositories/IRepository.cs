using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MilitaryManager.Core.Interfaces.Repositories
{
    public interface IRepository<TEntity, TType> where TEntity : class, IBaseEntity<TType>
    {
        Task AddAsync(TEntity entity);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByKeyAsync<TKey>(TKey key);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task DeleteRangeAsync(IEnumerable<TEntity> entities);
        IQueryable<TEntity> Query(params Expression<Func<TEntity, object>>[] includes);
        Task<int> SaveChangesAcync();
        Task AddRangeAsync(List<TEntity> entities);
        Task<IEnumerable<TEntity>> GetListBySpecAsync(ISpecification<TEntity> specification);
    }
}
