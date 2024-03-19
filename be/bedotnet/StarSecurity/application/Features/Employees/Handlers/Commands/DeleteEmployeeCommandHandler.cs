using application.Features.Employees.Requests.Commands;
using application.Persistences.Contracts;
using MediatR;

namespace application.Features.Employees.Handlers.Commands
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, Unit>
    {
        private readonly IEmployeeRepository _employeeRepository;
        public DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var client = await _employeeRepository.GetByIdAsync(request.Id) ?? throw new Exception("No Employee found");
            var isDelete = await _employeeRepository.DeleteAsync(client);
            if (!isDelete)
            {
                throw new Exception("Delete Employee failed!!");
            }
            return Unit.Value;
        }
    }
}
