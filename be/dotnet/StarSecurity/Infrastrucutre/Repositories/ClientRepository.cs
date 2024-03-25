using Application.Contracts.Persistences;
using Domain.Common.Enums;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Repositories.Common;
using StarSecurityAPI.Data;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories
{
    public class ClientRepository : GenericRepository<Client>, IClientRepository
	{
		public ClientRepository(StarSecurityAPIContext dbContext,
			ILogger<ClientRepository> logger)
			: base(dbContext,
				  logger)
		{
		}

		public async Task<Client> GetByEmailAsync(string email)
		{
			try
			{
				return await _dbContext.Client.AsNoTracking().FirstOrDefaultAsync(c => c.Email.Equals(email));
			}
			catch (Exception e)
			{
				Console.WriteLine(e.ToString());
				return null;
			}
		}

		public async Task<IEnumerable<Client>> GetByGenderAsync(string gender)
		{
			try
			{
				return await _dbContext.Client
					.AsNoTracking()
					.Where(c => c.Gender.Equals(gender))
					.ToListAsync();
			}
			catch (Exception e)
			{
				_logger.LogError(e, "Error while getting clients by gender");
				throw;
			}
		}

		public async Task<IEnumerable<Client>> GetByNameAsync(string name)
		{
			try
			{
				return await _dbContext.Client
					.AsNoTracking()
					.Where(c => c.Name.Equals(name))
					.ToListAsync();
			}
			catch (Exception e)
			{
				_logger.LogError(e, "Error while getting clients by name");
				throw;
			}
		}

		public async Task<IEnumerable<Client>> GetByYearOfBirthAsync(int birthOfYear)
		{
			try
			{
				return await _dbContext.Client
					.AsNoTracking()
					.Where(c => c.DateOfBirth.Year == birthOfYear)
					.ToListAsync();
			}
			catch (Exception e)
			{
				_logger.LogError(e, "Error while getting clients by birth Of Year");
				throw;
			}
		}
	}	
}