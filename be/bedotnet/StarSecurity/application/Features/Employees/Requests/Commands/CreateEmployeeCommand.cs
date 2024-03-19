using application.DTOs.EmployeesDTO;
using MediatR;

namespace application.Features.Employees.Requests.Commands
{
    public class CreateEmployeeCommand : IRequest<Guid>
    {
        public CreateEmployeeDTO CreateEmployeeDTO { get; set; }
    }
}
