using application.Contracts.Persistences;
using domain.Common.Enums;
using domain.Common.ValueObjects;
using domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.Common;
using infrastructure;

namespace Persistence.Repositories
{
    public class ClientRepository : GenericRepository<Client>, IClientRepository
	{
		public ClientRepository(StarSecurityDbContext dbContext, DbSet<Client> dbSet) : base(dbContext, dbSet)
		{
		}

		public async Task<Client> GetByEmailAsync(Email email)
		{
			return await _dbSet.FirstOrDefaultAsync(c => c.Email.Equals(email));
		}

		public async Task<IEnumerable<Client>> GetByGenderAsync(Gender gender)
		{
			return await _dbSet.Where(c => c.Gender == gender).ToListAsync();
		}

		public async Task<IEnumerable<Client>> GetByNameAsync(Name name)
		{
			return await _dbSet.Where(c => c.Name == name).ToListAsync();
		}

		public async Task<IEnumerable<Client>> GetByYearOfBirthAsync(int birthOfYear)
		{
			return await _dbSet.Where(c => c.DateOfBirth.Year == birthOfYear).ToListAsync();
		}
	}	
}