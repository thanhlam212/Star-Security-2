using Application.Contracts.Persistences;
using Application.DTOs.ClientsDTO.Validators;
using Application.Features.Clients.Requests.Commands;
using AutoMapper;
using Domain.Common.Enums;
using Domain.Common.Exceptions;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Application.Features.Clients.Handlers.Commands
{
	public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, Guid>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly CreateClientDTOValidator _validator;
		public CreateClientCommandHandler(
			IUnitOfWork unitOfWork,
			CreateClientDTOValidator validator)
		{
			_unitOfWork = unitOfWork;
			_validator = validator;
		}
		public async Task<Guid> Handle(CreateClientCommand request, CancellationToken cancellationToken)
		{
			var validationResult = await _validator.ValidateAsync(request.CreateClientDTO);
			if (!validationResult.IsValid)
			{
				throw new ValidationException(validationResult);
			}
			//var client = _mapper.Map<Client>(request.CreateClientDTO);
			var newClient = new Client(
				request.CreateClientDTO.Name,
				request.CreateClientDTO.Gender,
				request.CreateClientDTO.DateOfBirth,
				request.CreateClientDTO.Address,
				request.CreateClientDTO.ContactNumber,
				request.CreateClientDTO.Email,
				request.CreateClientDTO.CurrentOfferId);

			var isCreated = await _unitOfWork.ClientRepository.AddAsync(newClient);

			if (!isCreated)
			{
				throw new Exception("Failed to add client to repository.");
			}
			await _unitOfWork.CompleteAsync();

			return newClient.Id;
		}
	}
}
