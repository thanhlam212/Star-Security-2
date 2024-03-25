using Application.DTOs.EmployeesDTO;
using MediatR;

namespace Application.Features.Employees.Requests.Commands
{
    public class UpdateEmployeeCommand : IRequest<Unit>
    {
        public UpdateEmployeeDTO UpdateEmployeeDTO { get; set; }
    }
}
