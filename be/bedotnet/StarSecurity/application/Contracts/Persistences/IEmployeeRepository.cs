using application.Contracts.Persistences.Common;
using domain.Common.Enums;
using domain.Common.ValueObjects;
using domain.Entities;

namespace application.Contracts.Persistences
{
    public interface IEmployeeRepository : IHumanRepository<Employee>
    {
        Task<Employee> GetByEmployeeCodeAsync(string employeeCode);
        Task<IEnumerable<Employee>> GetByRoleAsync(Role role);
        Task<IEnumerable<Employee>> GetByProvideServiceAsync(ProvideService provideService);
        Task<IEnumerable<Employee>> GetByBranchIdAsync(Guid branchId);
    }
}
