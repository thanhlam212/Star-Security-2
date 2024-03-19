using MediatR;

namespace application.Features.Employees.Requests.Commands
{
    public class DeleteEmployeeCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
