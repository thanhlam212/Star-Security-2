using application.Features.Branches.Requests.Commands;
using application.Persistences.Contracts;
using AutoMapper;
using MediatR;

namespace application.Features.Branches.Handlers.Commands
{
	public class DeleteBranchCommandHandler : IRequestHandler<DeleteBranchCommand, Unit>
	{
		private readonly IBranchRepository _branchRepository;
		public DeleteBranchCommandHandler(IBranchRepository branchRepository)
		{
			_branchRepository = branchRepository;
		}
		public async Task<Unit> Handle(DeleteBranchCommand request, CancellationToken cancellationToken)
		{
			var branch = await _branchRepository.GetByIdAsync(request.Id) ?? throw new Exception("No branch found");
			var isDelete = await _branchRepository.DeleteAsync(branch);
			if (!isDelete)
			{
				throw new Exception("Delete branch failed!!");
			}
			return Unit.Value;
		}
	}
}
