using Microsoft.EntityFrameworkCore;
using MilitaryManager.Attachments.API.Data;
using MilitaryManager.Attachments.API.Entities;
using MilitaryManager.Attachments.API.Exceptions;
using MilitaryManager.Attachments.API.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilitaryManager.Attachments.API.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task Create(TEntity item)
        {
            await _dbSet.AddAsync(item);
        }

        public async Task<TEntity> FindById(int id)
        {
            return await _dbSet.FindAsync(id) ?? throw new NotFoundException($"{typeof(TEntity).Name} with id {id} not found.");
        }

        public async Task<IEnumerable<TEntity>> Get()
        {
            var entities = await _dbSet.AsNoTracking().ToListAsync();

            if (entities is null)
            {
                throw new NotFoundException($"{typeof(TEntity).Name} not found.");
            }

            return entities;
        }

        public async Task Remove(int id)
        {
            var entity = await FindById(id);
            _dbSet.Remove(entity);
        }

        public async Task Update(TEntity item)
        {
            var entity = await FindById(item.Id);
            _context.Entry(entity).State = EntityState.Modified;
            await Task.Run(() => _dbSet.Update(item));
        }
    }
}
