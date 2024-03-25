using Application.Contracts.Persistences;
using Application.Features.Employees.Requests.Commands;
using Domain.Common.Exceptions;
using Domain.Entities;
using MediatR;

namespace Application.Features.Employees.Handlers.Commands
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, Unit>
    {
		private readonly IUnitOfWork _unitOfWork;
		public DeleteEmployeeCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var client = await _unitOfWork.EmployeeRepository.GetByIdAsync(request.Id) 
                ?? throw new NotFoundException(nameof(Employee), request.Id);
            var isDelete = await _unitOfWork.EmployeeRepository.DeleteAsync(client);
            if (!isDelete)
            {
                throw new Exception("Delete Employee failed!!");
            }
            return Unit.Value;
        }
    }
}
