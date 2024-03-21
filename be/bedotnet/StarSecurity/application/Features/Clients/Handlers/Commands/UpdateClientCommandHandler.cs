using application.Contracts.Persistences;
using application.DTOs.ClientsDTO.Validators;
using application.Features.Clients.Requests.Commands;
using AutoMapper;
using domain.Common.Exceptions;
using domain.Entities;
using MediatR;

namespace application.Features.Clients.Handlers.Commands
{
    public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, Unit>
	{
		private readonly IClientRepository _clientRepository;
		private readonly UpdateClientDTOValidator _validator;
		private readonly IMapper _mapper;

		public UpdateClientCommandHandler(
			IClientRepository clientRepository,
			UpdateClientDTOValidator validator,
			IMapper mapper)
		{
			_clientRepository = clientRepository;
			_validator = validator;
			_mapper = mapper;
		}
		public async Task<Unit> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
		{
			var validationResult = await _validator.ValidateAsync(request.UpdateClientDTO);
			if (!validationResult.IsValid)
			{
				throw new ValidationException(validationResult);
			}
			var client = await _clientRepository.GetByIdAsync(request.UpdateClientDTO.Id) 
				?? throw new NotFoundException(nameof(Client), request.UpdateClientDTO.Id);
			_mapper.Map(request.UpdateClientDTO, client);

			var isUpdated = await _clientRepository.UpdateAsync(client);
			if (!isUpdated)
			{
				throw new Exception("No client updated!!");
			}
			return Unit.Value;
		}
	}
}
