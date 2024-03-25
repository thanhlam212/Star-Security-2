using Application.Contracts.Persistences;
using Domain.Common.Enums;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Repositories.Common;
using StarSecurityAPI.Data;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace Infrastructure.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
	{
		public EmployeeRepository(StarSecurityAPIContext dbContext,
			ILogger<EmployeeRepository> logger)
			: base(dbContext,
				  logger)
		{
		}

		public async Task<IEnumerable<Employee>> GetByBranchIdAsync(Guid branchId)
		{
			try
			{
				return await _dbContext.Employee
					.AsNoTracking()
					.Where(c => c.BranchId == branchId)
					.ToListAsync();
			}
			catch (Exception e)
			{
				_logger.LogError(e, "Error while getting Employees by BranchId");
				throw;
			}
		}

		public async Task<Employee> GetByEmailAsync(string email)
		{
			try
			{
				return await _dbContext.Employee.AsNoTracking().FirstOrDefaultAsync(c => c.Email.Equals(email));
			}
			catch (Exception e)
			{
				Console.WriteLine(e.ToString());
				return null;
			}
		}

		public async Task<Employee> GetByEmployeeCodeAsync(string employeeCode)
		{
			try
			{
				return await _dbContext.Employee.AsNoTracking().FirstOrDefaultAsync(c => c.EmployeeCode.Equals(employeeCode));
			}
			catch (Exception e)
			{
				Console.WriteLine(e.ToString());
				return null;
			}
		}

		public async Task<IEnumerable<Employee>> GetByGenderAsync(string gender)
		{
			try
			{
				return await _dbContext.Employee
					.AsNoTracking()
					.Where(e => e.Gender.Equals(gender))
					.ToListAsync();
			}
			catch (Exception e)
			{
				_logger.LogError(e, "Error while getting Employees by gender");
				throw;
			}
		}

		public async Task<IEnumerable<Employee>> GetByNameAsync(string name)
		{
			try
			{
				return await _dbContext.Employee
					.AsNoTracking()
					.Where(e => e.Name.Equals(name))
					.ToListAsync();
			}
			catch (Exception e)
			{
				_logger.LogError(e, "Error while getting Employees by name");
				return null;
			}
		}

			public async Task<IEnumerable<Employee>> GetByProvideServiceAsync(string provideService)
		{
			try
			{
				return await _dbContext.Employee
					.AsNoTracking()
					.Where(e => e.ProvideService.Equals(provideService))
					.ToListAsync();
			}
			catch (Exception e)
			{
				_logger.LogError(e, "Error while getting Employees by provideService");
				throw;
			}
		}

		public async Task<IEnumerable<Employee>> GetByRoleAsync(string role)
		{
			try
			{
				return await _dbContext.Employee
					.AsNoTracking()
					.Where(e => e.Role.Equals(role))
					.ToListAsync();
			}
			catch (Exception e)
			{
				_logger.LogError(e, "Error while getting Employees by role");
				throw;
			}
		}

		public async Task<IEnumerable<Employee>> GetByYearOfBirthAsync(int birthOfYear)
		{
			try
			{
				return await _dbContext.Employee
					.AsNoTracking()
					.Where(e => e.DateOfBirth.Year == birthOfYear)
					.ToListAsync();
			}
			catch (Exception e)
			{
				_logger.LogError(e, "Error while getting Employees by birth Of Year");
				throw;
			}
		}
	}
}