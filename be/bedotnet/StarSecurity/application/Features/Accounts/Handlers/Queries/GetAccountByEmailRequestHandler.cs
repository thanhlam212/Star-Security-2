using application.DTOs.AccountsDTO;
using application.Features.Accounts.Requests.Queries;
using application.Persistences.Contracts;
using AutoMapper;
using domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Features.Accounts.Handlers.Queries
{
	public class GetAccountByEmailRequestHandler : IRequestHandler<GetAccountByEmailRequest, GetAccountDTO>
	{
		private readonly IAccountRepository _accountRepository;
		private readonly IMapper _mapper;

		public GetAccountByEmailRequestHandler(IAccountRepository accountRepository, IMapper mapper)
		{
			_accountRepository = accountRepository;
			_mapper = mapper;
		}
		public async Task<GetAccountDTO> Handle(GetAccountByEmailRequest request, CancellationToken cancellationToken)
		{
			var account = await _accountRepository.GetByEmailAsync(request.Email) ?? throw new Exception("No Account found!");
			return _mapper.Map<GetAccountDTO>(account);
		}
	}
}
