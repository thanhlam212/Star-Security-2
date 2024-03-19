using application.DTOs.BranchesDTO.Validator;
using application.DTOs.ClientsDTO.Validators;
using application.Features.Branches.Requests.Commands;
using application.Features.Clients.Requests.Commands;
using application.Persistences.Contracts;
using domain.Common.ValueObjects;
using domain.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace application.Features.Clients.Handlers.Commands
{
	public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, Guid>
	{
		private readonly IClientRepository _clientRepository;
		private readonly CreateClientDTOValidator _validator;

		public CreateClientCommandHandler(
			IClientRepository clientRepository,
			CreateClientDTOValidator validator
			)
        {
			_clientRepository = clientRepository;
			_validator = validator;
		}
        public async Task<Guid> Handle(CreateClientCommand request, CancellationToken cancellationToken)
		{
			var validationResult = await _validator.ValidateAsync(request.CreateClientDTO);
			if (!validationResult.IsValid)
			{
				throw new Exception();
			}
			var client = new Client(
				new Name(request.CreateClientDTO.Name),
				request.CreateClientDTO.Gender,
				request.CreateClientDTO.Address,
				request.CreateClientDTO.ContactNumber,
				new Email(request.CreateClientDTO.Email),
				request.CreateClientDTO.CurrentOfferId
				);
			var isCreated = await _clientRepository.AddAsync(client);

			if (!isCreated)
			{
				throw new Exception("Failed to add client to repository.");
			}

			return client.Id;
		}
	}
}
