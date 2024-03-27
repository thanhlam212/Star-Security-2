using Application.Contracts.Persistences.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Common;
using StarSecurityAPI.Data;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories.Common
{
	public class HumanRepository<T> : GenericRepository<T>, IHumanRepository<T> where T : Human
	{
		public HumanRepository(
			StarSecurityAPIContext dbContext,
			ILogger<T> logger)
			: base(
				  dbContext, 
				  logger)
		{
		}

		public async Task<T> GetByEmailAsync(string email)
		{
			return await _dbSet.FirstOrDefaultAsync(h => h.Email.Equals(email));
		}

		public async Task<IEnumerable<T>> GetByGenderAsync(string gender)
		{
			return await _dbSet.Where(h => h.Gender.Equals(gender)).ToListAsync();
		}

		public async Task<IEnumerable<T>> GetByNameAsync(string name)
		{
			return await _dbSet.Where(h => h.Name.Equals(name)).ToListAsync();
		}

		public async Task<IEnumerable<T>> GetByYearOfBirthAsync(int birthOfYear)
		{
			return await _dbSet.Where(h => h.DateOfBirth.Year == birthOfYear).ToListAsync();
		}
	}
}
