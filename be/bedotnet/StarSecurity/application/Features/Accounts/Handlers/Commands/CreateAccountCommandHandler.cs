using application.Contracts.Persistences;
using application.DTOs.AccountsDTO.Validators;
using application.Features.Accounts.Requests.Commands;
using domain.Common.Exceptions;
using domain.Common.ValueObjects;
using domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Features.Accounts.Handlers.Commands
{
    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, Guid>
	{
		private readonly IAccountRepository _accountRepository;
		private readonly CreateAccountDTOValidator _validator;

		public CreateAccountCommandHandler(
			IAccountRepository accountRepository, 
			CreateAccountDTOValidator validator)
        {
			_accountRepository = accountRepository;
			_validator = validator;
		}
        public async Task<Guid> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
		{
			var validationResult = await _validator.ValidateAsync(request.CreateAccountDTO);
			if (!validationResult.IsValid)
			{
				throw new ValidationException(validationResult);
			}
			var account = new Account(
				new Email(request.CreateAccountDTO.Email), 
				request.CreateAccountDTO.PasswordHash,
				request.CreateAccountDTO.EmployeeId
				);
				
			var isCreated = await _accountRepository.AddAsync(account);

			if (!isCreated)
			{
				throw new Exception("Failed to add account to repository.");
			}

			return account.Id;
		}
	}
}
