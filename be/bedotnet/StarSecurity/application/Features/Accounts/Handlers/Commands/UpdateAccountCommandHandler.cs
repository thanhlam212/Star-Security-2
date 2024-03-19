using application.DTOs.AccountsDTO;
using application.DTOs.AccountsDTO.Validators;
using application.Features.Accounts.Requests.Commands;
using application.Persistences.Contracts;
using AutoMapper;
using domain.Common.ValueObjects;
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
				throw new Exception();
			}
			var account = await _accountRepository.GetByIdAsync(request.UpdateAccountDTO.Id) ?? throw new Exception("No Account found!");

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
