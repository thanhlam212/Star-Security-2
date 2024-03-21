using application.Contracts.Persistences;
using domain.Common.ValueObjects;
using domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.Common;

namespace Persistence.Repositories
{
    public class BranchRepository : GenericRepository<Branch>, IBranchRepository
	{
		public BranchRepository(StarSecurityDbContext dbContext, DbSet<Branch> dbSet) : base(dbContext, dbSet)
		{
		}

		public async Task<Branch> GetByNameAsync(Name name)
		{
			return await _dbSet.FirstOrDefaultAsync(b => b.Name.Equals(name));
		}
	}
}