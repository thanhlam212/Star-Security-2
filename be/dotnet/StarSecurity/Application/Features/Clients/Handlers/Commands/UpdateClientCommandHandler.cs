using Application.Contracts.Persistences;
using Application.DTOs.ClientsDTO.Validators;
using Application.Features.Clients.Requests.Commands;
using AutoMapper;
using Domain.Common.Exceptions;
using Domain.Entities;
using MediatR;

namespace Application.Features.Clients.Handlers.Commands
{
    public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, Unit>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly UpdateClientDTOValidator _validator;
		private readonly IMapper _mapper;

		public UpdateClientCommandHandler(
			IUnitOfWork unitOfWork,
			UpdateClientDTOValidator validator,
			IMapper mapper)
		{
			_unitOfWork = unitOfWork;
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
			var client = await _unitOfWork.ClientRepository.GetByIdAsync(request.UpdateClientDTO.Id) 
				?? throw new NotFoundException(nameof(Client), request.UpdateClientDTO.Id);
			_mapper.Map(request.UpdateClientDTO, client);

			var isUpdated = await _unitOfWork.ClientRepository.UpdateAsync(client);
			if (!isUpdated)
			{
				throw new Exception("No client updated!!");
			}
			await _unitOfWork.CompleteAsync();
			return Unit.Value;
		}
	}
}
