using application.Contracts.Persistences.Common;
using domain.Common.Abstractions;
using domain.Common.Enums;
using domain.Common.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Common
{
    public class HumanRepository<T> : GenericRepository<T>, IHumanRepository<T> where T : Human
	{
		public HumanRepository(
			StarSecurityDbContext dbContext, 
			DbSet<T> dbSet) 
			: base(
				  dbContext, 
				  dbSet)
		{
		}

		public async Task<T> GetByEmailAsync(Email email)
		{
			return await _dbSet.FirstOrDefaultAsync(h => h.Email.Equals(email));
		}

		public async Task<IEnumerable<T>> GetByGenderAsync(Gender gender)
		{
			return await _dbSet.Where(h => h.Gender == gender).ToListAsync();
		}

		public async Task<IEnumerable<T>> GetByNameAsync(Name name)
		{
			return await _dbSet.Where(h => h.Name.Equals(name)).ToListAsync();
		}

		public async Task<IEnumerable<T>> GetByYearOfBirthAsync(int birthOfYear)
		{
			return await _dbSet.Where(h => h.DateOfBirth.Year == birthOfYear).ToListAsync();
		}
	}
}
