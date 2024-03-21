using application.Contracts.Persistences;
using application.DTOs.AccountsDTO;
using application.DTOs.AccountsDTO.Validators;
using application.Features.Accounts.Requests.Commands;
using AutoMapper;
using domain.Common.Exceptions;
using domain.Common.ValueObjects;
using domain.Entities;
using MediatR;

namespace application.Features.Accounts.Handlers.Commands
{
    public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand, Unit>
	{
		private readonly IAccountRepository _accountRepository;
		private readonly UpdateAccountDTOValidator _validator;

		public UpdateAccountCommandHandler(
			IAccountRepository accountRepository,
			UpdateAccountDTOValidator validator)
		{
			_accountRepository = accountRepository;
			_validator = validator;
		}
		public async Task<Unit> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
		{
			var validationResult = await _validator.ValidateAsync(request.UpdateAccountDTO);
			if (!validationResult.IsValid)
			{
				throw new ValidationException(validationResult);
			}
			var account = await _accountRepository.GetByIdAsync(request.UpdateAccountDTO.Id) 
				?? throw new NotFoundException(nameof(Account), request.UpdateAccountDTO.Id);

			account.Email = new Email(request.UpdateAccountDTO.Email);
			account.PasswordHash = request.UpdateAccountDTO.PasswordHash;
			account.EmployeeId = request.UpdateAccountDTO.EmployeeId;

			var isUpdated = await _accountRepository.UpdateAsync(account);
			if (!isUpdated)
			{
				throw new Exception("Account updated failed!");
			}
			return Unit.Value;
		}
	}
}
