using application.Contracts.Persistences;
using application.Features.Employees.Requests.Commands;
using domain.Common.Exceptions;
using domain.Entities;
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
            var client = await _employeeRepository.GetByIdAsync(request.Id) 
                ?? throw new NotFoundException(nameof(Employee), request.Id);
            var isDelete = await _employeeRepository.DeleteAsync(client);
            if (!isDelete)
            {
                throw new Exception("Delete Employee failed!!");
            }
            return Unit.Value;
        }
    }
}
