using application.Persistences.Contracts.Common;
using domain.Entities;

namespace application.Persistences.Contracts
{
    public interface IEmployeeRepository : IHumanRepository<Employee>
	{
	}
}
