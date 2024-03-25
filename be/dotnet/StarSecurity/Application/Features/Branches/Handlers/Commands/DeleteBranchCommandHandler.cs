using Application.Contracts.Persistences;
using Application.Features.Branches.Requests.Commands;
using Domain.Common.Exceptions;
using Domain.Entities;
using MediatR;

namespace Application.Features.Branches.Handlers.Commands
{
    public class DeleteBranchCommandHandler : IRequestHandler<DeleteBranchCommand, Unit>
	{
		private readonly IUnitOfWork _unitOfWork;
		public DeleteBranchCommandHandler(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public async Task<Unit> Handle(DeleteBranchCommand request, CancellationToken cancellationToken)
		{
			var branch = await _unitOfWork.BranchRepository.GetByIdAsync(request.Id) 
				?? throw new NotFoundException(nameof(Branch), request.Id);
			var isDelete = await _unitOfWork.BranchRepository.DeleteAsync(branch);
			if (!isDelete)
			{
				throw new Exception("Delete branch failed!!");
			}
			return Unit.Value;
		}
	}
}
