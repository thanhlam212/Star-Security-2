using Application.Contracts.Persistences.Common;
using Domain.Entities;

namespace Application.Contracts.Persistences
{
	public interface IEmployeeRepository : IHumanRepository<Employee>
	{
		Task<Employee> GetByEmployeeCodeAsync(string employeeCode);
		Task<IEnumerable<Employee>> GetByRoleAsync(string role);
		Task<IEnumerable<Employee>> GetByProvideServiceAsync(string provideService);
		Task<IEnumerable<Employee>> GetByBranchIdAsync(Guid branchId);
	}
}
