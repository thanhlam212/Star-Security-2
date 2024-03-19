using application.DTOs.AccountsDTO;
using application.Features.Accounts.Requests.Queries;
using application.Persistences.Contracts;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Features.Accounts.Handlers.Queries
{
	public class GetAllAccountsRequestHandler : IRequestHandler<GetAllAccountsRequest, ICollection<GetAccountDTO>>
	{
		private readonly IAccountRepository _accountRepository;
		private readonly IMapper _mapper;

		public GetAllAccountsRequestHandler(IAccountRepository accountRepository, IMapper mapper)
		{
			_accountRepository = accountRepository;
			_mapper = mapper;
		}

		public async Task<ICollection<GetAccountDTO>> Handle(GetAllAccountsRequest request, CancellationToken cancellationToken)
		{
			var accounts = await _accountRepository.GetAllAsync() ?? throw new Exception("No Account found!");
			return _mapper.Map<ICollection<GetAccountDTO>>(accounts);
		}
	}
}
