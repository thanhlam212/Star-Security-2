using Application.Contracts.Persistences;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Repositories.Common;
using StarSecurityAPI.Data;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Microsoft.Extensions.Logging;


namespace Infrastructure.Repositories
{
	public class BranchRepository : GenericRepository<Branch>, IBranchRepository
	{
		public BranchRepository(StarSecurityAPIContext dbContext,
			ILogger<BranchRepository> logger)
			: base(dbContext,
				  logger)
		{
		}

		public async Task<Branch> GetByIdAsync(Guid id)
		{
			return await _dbContext.Branch.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);
		}
	}
}