using Application.Contracts.Persistences;
using Application.DTOs.AccountsDTO.Validators;
using Application.Features.Accounts.Requests.Commands;
using Domain.Common.Exceptions;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Accounts.Handlers.Commands
{
	public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, Guid>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly CreateAccountDTOValidator _validator;

		public CreateAccountCommandHandler(
			IUnitOfWork unitOfWork,
			CreateAccountDTOValidator validator)
		{
			_unitOfWork = unitOfWork;
			_validator = validator;
		}
		public async Task<Guid> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
		{
			var validationResult = await _validator.ValidateAsync(request.CreateAccountDTO);
			if (!validationResult.IsValid)
			{
				throw new ValidationException(validationResult);
			}

			//var account = _mapper.Map<Account>(request.CreateAccountDTO);

			var newAccount = new Account(
				request.CreateAccountDTO.Email,
				request.CreateAccountDTO.PasswordHash,
				request.CreateAccountDTO.EmployeeId);

			var isCreated = await _unitOfWork.AccountRepository.AddAsync(newAccount);

			if (!isCreated)
			{
				throw new Exception("Failed to add account to repository.");
			}

			return newAccount.Id;
		}
	}
}
