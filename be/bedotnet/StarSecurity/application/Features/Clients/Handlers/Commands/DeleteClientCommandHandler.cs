using application.Contracts.Persistences;
using application.Features.Clients.Requests.Commands;
using domain.Common.Exceptions;
using domain.Entities;
using MediatR;

namespace application.Features.Clients.Handlers.Commands
{
    public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand, Unit>
	{
		private readonly IClientRepository _clientRepository;
		public DeleteClientCommandHandler(IClientRepository clientRepository)
		{
			_clientRepository = clientRepository;
		}
		public async Task<Unit> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
		{
			var client = await _clientRepository.GetByIdAsync(request.Id) 
				?? throw new NotFoundException(nameof(Client), request.Id);
			var isDelete = await _clientRepository.DeleteAsync(client);
			if (!isDelete)
			{
				throw new Exception("Delete client failed!!");
			}
			return Unit.Value;
		}
	}
}
