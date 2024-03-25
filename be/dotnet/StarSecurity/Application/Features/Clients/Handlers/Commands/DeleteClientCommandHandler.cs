using Application.Contracts.Persistences;
using Application.Features.Clients.Requests.Commands;
using Domain.Common.Exceptions;
using Domain.Entities;
using MediatR;

namespace Application.Features.Clients.Handlers.Commands
{
    public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand, Unit>
	{
		private readonly IUnitOfWork _unitOfWork;
		public DeleteClientCommandHandler(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public async Task<Unit> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
		{
			var client = await _unitOfWork.ClientRepository.GetByIdAsync(request.Id) 
				?? throw new NotFoundException(nameof(Client), request.Id);
			var isDelete = await _unitOfWork.ClientRepository.DeleteAsync(client);
			if (!isDelete)
			{
				throw new Exception("Delete client failed!!");
			}
			await _unitOfWork.CompleteAsync();
			return Unit.Value;
		}
	}
}
