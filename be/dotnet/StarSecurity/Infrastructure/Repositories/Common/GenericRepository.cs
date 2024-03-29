﻿using Application.Contracts.Persistences.Common;
using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StarSecurityAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Common
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		protected StarSecurityAPIContext _dbContext;
		internal DbSet<T> _dbSet;
		protected readonly ILogger _logger;

		public GenericRepository(StarSecurityAPIContext dbContext, ILogger logger)
		{
			_dbContext = dbContext;
			_logger = logger;
			_dbSet = _dbContext.Set<T>();
		}

		public async Task<IEnumerable<T>> GetAllAsync()
		{
			return await _dbSet.AsNoTracking().ToListAsync();
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
