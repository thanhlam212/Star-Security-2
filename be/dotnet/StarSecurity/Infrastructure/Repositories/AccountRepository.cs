using Application.Contracts.Persistences;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarSecurityAPI.Data;
using Infrastructure.Repositories.Common;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
	{
		public AccountRepository
			(StarSecurityAPIContext dbContext,
			ILogger<AccountRepository> logger)
			: base(dbContext,
				  logger)
		{
		}

		public async Task<Account> GetByEmailAsync(string email)
		{
			try
			{
				return await _dbContext.Account.AsNoTracking().FirstOrDefaultAsync(a => a.Email.Equals(email));
			}
			catch (Exception e)
			{
				Console.WriteLine(e.ToString());
				return null;
			}
		}
	}
}