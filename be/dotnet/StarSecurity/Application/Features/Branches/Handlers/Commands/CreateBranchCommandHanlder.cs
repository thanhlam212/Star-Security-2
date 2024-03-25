using Application.Contracts.Persistences;
using Application.DTOs.AccountsDTO.Validators;
using Application.DTOs.BranchesDTO.Validator;
using Application.Features.Accounts.Requests.Commands;
using Application.Features.Branches.Requests.Commands;
using AutoMapper;
using Domain.Common.Exceptions;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Application.Features.Branches.Handlers.Commands
{
	public class CreateBranchCommandHanlder : IRequestHandler<CreateBranchCommand, Guid>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly CreateBranchDTOValidator _validator;

		public CreateBranchCommandHanlder(
			IUnitOfWork unitOfWork,
			CreateBranchDTOValidator validator)
		{
			_unitOfWork = unitOfWork;
			_validator = validator;
		}
		public async Task<Guid> Handle(CreateBranchCommand request, CancellationToken cancellationToken)
		{
			var validationResult = await _validator.ValidateAsync(request.CreateBranchDTO);
			if (!validationResult.IsValid)
			{
				throw new ValidationException(validationResult);
			}			
			var newBranch = new Branch(
				request.CreateBranchDTO.Name,
				request.CreateBranchDTO.Region,
				request.CreateBranchDTO.ContactDetail
				);
			//var branch = _mapper.Map<Branch>(newBranch);
			var isCreated = await _unitOfWork.BranchRepository.AddAsync(newBranch);

			if (!isCreated)
			{
				throw new Exception("Failed to add Branch to repository.");
			}

			return newBranch.Id;
		}
	}
}
