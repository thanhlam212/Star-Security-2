using application.Features.Accounts.Requests.Commands;
using application.Persistences.Contracts;
using AutoMapper;
using domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Features.Accounts.Handlers.Commands
{
	public class CreateAccountComanndHandler : IRequestHandler<CreateAccountComannd, Guid>
	{
		private readonly IAccountRepository _accountRepository;
		private readonly IMapper _mapper;

		public CreateAccountComanndHandler(IAccountRepository accountRepository, IMapper mapper)
        {
			_accountRepository = accountRepository;
			_mapper = mapper;
		}
        public async Task<Guid> Handle(CreateAccountComannd request, CancellationToken cancellationToken)
		{
			var account = _mapper.Map<Account>(request.CreateAccountDTO);
			var isAdded = await _accountRepository.AddAsync(account);

			if (!isAdded)
			{
				throw new Exception("Failed to add account to repository.");
			}

			return account.Id;
		}
	}
}
