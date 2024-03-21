using application.Contracts.Persistences;
using domain.Common.Enums;
using domain.Common.ValueObjects;
using domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.Common;

namespace Persistence.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
	{
		public EmployeeRepository(StarSecurityDbContext dbContext, DbSet<Employee> dbSet) : base(dbContext, dbSet)
		{
		}

		public async Task<IEnumerable<Employee>> GetByBranchIdAsync(Guid branchId)
		{
			return await _dbSet.Where(e => e.BranchId == branchId).ToListAsync();
		}

		public async Task<Employee> GetByEmailAsync(Email email)
		{
			return await _dbSet.FirstOrDefaultAsync(e => e.Email.Equals(email));
		}

		public async Task<Employee> GetByEmployeeCodeAsync(string employeeCode)
		{
			return await _dbSet.FirstOrDefaultAsync(e => e.EmployeeCode == employeeCode);
		}

		public async Task<IEnumerable<Employee>> GetByGenderAsync(Gender gender)
		{
			return await _dbSet.Where(e => e.Gender == gender).ToListAsync();
		}

		public async Task<IEnumerable<Employee>> GetByNameAsync(Name name)
		{
			return await _dbSet.Where(e => e.Name == name).ToListAsync();
		}

		public async Task<IEnumerable<Employee>> GetByProvideServiceAsync(ProvideService provideService)
		{
			return await _dbSet.Where(e => e.ProvideService == provideService).ToListAsync();
		}

		public async Task<IEnumerable<Employee>> GetByRoleAsync(Role role)
		{
			return await _dbSet.Where(e => e.Role == role).ToListAsync();
		}

		public async Task<IEnumerable<Employee>> GetByYearOfBirthAsync(int birthOfYear)
		{
			return await _dbSet.Where(e => e.DateOfBirth.Year == birthOfYear).ToListAsync();
		}
	}
}