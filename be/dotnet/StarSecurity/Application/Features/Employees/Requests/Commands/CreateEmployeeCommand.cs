using Application.DTOs.EmployeesDTO;
using MediatR;

namespace Application.Features.Employees.Requests.Commands
{
    public class CreateEmployeeCommand : IRequest<Guid>
    {
        public CreateEmployeeDTO CreateEmployeeDTO { get; set; }
    }
}
