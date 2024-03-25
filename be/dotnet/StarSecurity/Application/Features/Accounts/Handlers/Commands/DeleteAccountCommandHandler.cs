using Application.Contracts.Persistences;
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
    public class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand, Unit>
	{
		private readonly IUnitOfWork _unitOfWork;

		public DeleteAccountCommandHandler(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public async Task<Unit> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
		{
			var account = await _unitOfWork.AccountRepository.GetByIdAsync(request.Id) 
				?? throw new NotFoundException(nameof(Account), request.Id);
			var isDelete = await _unitOfWork.AccountRepository.DeleteAsync(account);

			if (!isDelete)
			{
				throw new Exception("Failed to add account to repository.");
			}

			return Unit.Value;
		}
	}
}
