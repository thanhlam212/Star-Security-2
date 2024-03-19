using application.Persistences.Contracts.Common;
using domain.Common.Enums;
using domain.Common.ValueObjects;
using domain.Entities;

namespace application.Persistences.Contracts
{
    public interface IEmployeeRepository : IHumanRepository<Employee>
	{
		Task<Employee> GetByEmployeeCodeAsync(string employeeCode);
		Task<IEnumerable<Employee>> GetByRoleAsync(Role role);
		Task<IEnumerable<Employee>> GetByProvideServiceAsync(ProvideService provideService);
		Task<IEnumerable<Employee>> GetByBranchIdAsync(Guid branchId);
	}
}
