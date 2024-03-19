using application.DTOs.EmployeesDTO;
using MediatR;

namespace application.Features.Employees.Requests.Commands
{
    public class UpdateEmployeeCommand : IRequest<Unit>
    {
        public UpdateEmployeeDTO UpdateEmployeeDTO { get; set; }
    }
}
