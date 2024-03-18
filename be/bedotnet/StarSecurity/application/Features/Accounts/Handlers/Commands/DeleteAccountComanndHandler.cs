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
	public class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand, Unit>
	{
		private readonly IAccountRepository _accountRepository;
		private readonly IMapper _mapper;

		public DeleteAccountCommandHandler(IAccountRepository accountRepository, IMapper mapper)
		{
			_accountRepository = accountRepository;
			_mapper = mapper;
		}
		public async Task<Unit> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
		{
			var account = await _accountRepository.GetByIdAsync(request.Id) ?? throw new Exception("No Account found!");
			var isDelete = await _accountRepository.DeleteAsync(account);

			if (!isDelete)
			{
				throw new Exception("Failed to add account to repository.");
			}

			return Unit.Value;
		}
	}
}
