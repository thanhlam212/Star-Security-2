using application.Contracts.Persistences;
using domain.Common.ValueObjects;
using domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.Common;
using infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
	{
		public AccountRepository(StarSecurityDbContext dbContext, DbSet<Account> dbSet) : base(dbContext, dbSet)
		{
		}

		public async Task<Account> GetByEmailAsync(Email email)
		{
			return await _dbSet.FirstOrDefaultAsync(a => a.Email.Equals(email));
		}
	}
}