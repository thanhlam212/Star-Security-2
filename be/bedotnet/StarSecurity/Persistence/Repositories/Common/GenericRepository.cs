using application.Contracts.Persistences.Common;
using domain.Common.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Common
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly StarSecurityDbContext _dbContext;
		protected readonly DbSet<T> _dbSet;

        public GenericRepository(StarSecurityDbContext dbContext, DbSet<T> dbSet)
        {
            _dbContext = dbContext
                ?? throw new ArgumentNullException(nameof(_dbContext));
            _dbSet = _dbContext.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }
        public async Task<bool> AddAsync(T entity)
        {
            //await _dbSet.AddAsync(entity);
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteAsync(T entity)
        {
            if (entity is Entity baseEntity)
            {
                baseEntity.MarkAsDeleted();
                _dbContext.Entry(entity).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<bool> UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
