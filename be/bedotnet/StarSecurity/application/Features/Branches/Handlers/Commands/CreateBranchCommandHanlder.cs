using application.DTOs.BranchesDTO.Validator;
using application.Features.Branches.Requests.Commands;
using application.Persistences.Contracts;
using AutoMapper;
using domain.Common.Enums;
using domain.Common.ValueObjects;
using domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace application.Features.Branches.Handlers.Commands
{
	public class CreateBranchCommandHanlder : IRequestHandler<CreateBranchCommand, Guid>
	{
		private readonly IBranchRepository _branchRepository;
		private readonly CreateBranchDTOValidator _validator;

		public CreateBranchCommandHanlder(
			IBranchRepository branchRepository,
			CreateBranchDTOValidator validator)
		{
			_branchRepository = branchRepository;
			_validator = validator;
		}
		public async Task<Guid> Handle(CreateBranchCommand request, CancellationToken cancellationToken)
		{
			var validationResult = await _validator.ValidateAsync(request.CreateBranchDTO);
			if (!validationResult.IsValid)
			{
				throw new Exception();
			}
			var branch = new Branch(
				new Name(request.CreateBranchDTO.Name),
				request.CreateBranchDTO.Region,
				request.CreateBranchDTO.ContactDetail,
				request.CreateBranchDTO.Manager
				);
			var isCreated = await _branchRepository.AddAsync(branch);

			if (!isCreated)
			{
				throw new Exception("Failed to add branch to repository.");
			}

			return branch.Id;
		}
	}
}
