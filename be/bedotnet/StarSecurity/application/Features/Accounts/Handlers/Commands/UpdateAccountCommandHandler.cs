using application.Features.Accounts.Requests.Commands;
using application.Persistences.Contracts;
using AutoMapper;
using MediatR;

namespace application.Features.Accounts.Handlers.Commands
{
	public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand, Unit>
	{
		private readonly IAccountRepository _accountRepository;
		private readonly IMapper _mapper;

		public UpdateAccountCommandHandler(IAccountRepository accountRepository, IMapper mapper)
		{
			_accountRepository = accountRepository;
			_mapper = mapper;
		}
		public async Task<Unit> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
		{
			var account = await _accountRepository.GetByIdAsync(request.UpdateAccountDTO.Id) ?? throw new Exception("No Account found!");
			_mapper.Map(request.UpdateAccountDTO, account);

			var updateAccount = await _accountRepository.UpdateAsync(account);
			if (!updateAccount)
			{
				throw new Exception("Account updated failed!");
			}
			return Unit.Value;
		}
	}
}
