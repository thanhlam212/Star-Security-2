using application.DTOs.AccountsDTO;
using application.Features.Accounts.Requests.Queries;
using application.Persistences.Contracts;
using AutoMapper;
using domain.Entities;
using MediatR;

namespace application.Features.Accounts.Handlers.Queries
{
	public class GetAccountByIdRequestHandler : IRequestHandler<GetAccountByIdRequest, GetAccountDTO>
	{
		private readonly IAccountRepository _accountRepository;
		private readonly IMapper _mapper;

		public GetAccountByIdRequestHandler(IAccountRepository accountRepository, IMapper mapper)
		{
			_accountRepository = accountRepository;
			_mapper = mapper;
		}
		public async Task<GetAccountDTO> Handle(GetAccountByIdRequest request, CancellationToken cancellationToken)
		{
			var account = await _accountRepository.GetByIdAsync(request.Id) ?? throw new Exception("No Account found!");
			return _mapper.Map<GetAccountDTO>(account);
		}
	}
}
