using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryManager.Infrastructure.Data.Repositories
{
    public class BaseRepository<TEntity> 
    {
        protected readonly MilitaryManagerDbContext _dbContext;
        //protected readonly DbSet<TEntity> _dbSet; 
    }
}
