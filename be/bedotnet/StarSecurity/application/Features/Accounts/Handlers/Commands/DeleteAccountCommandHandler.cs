using application.Contracts.Persistences;
using application.Features.Accounts.Requests.Commands;
using AutoMapper;
using domain.Common.Exceptions;
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

		public DeleteAccountCommandHandler(IAccountRepository accountRepository)
		{
			_accountRepository = accountRepository;
		}
		public async Task<Unit> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
		{
			var account = await _accountRepository.GetByIdAsync(request.Id) 
				?? throw new NotFoundException(nameof(Account), request.Id);
			var isDelete = await _accountRepository.DeleteAsync(account);

			if (!isDelete)
			{
				throw new Exception("Failed to add account to repository.");
			}

			return Unit.Value;
		}
	}
}
