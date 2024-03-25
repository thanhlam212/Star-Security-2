using Application.Contracts.Persistences;
using Application.DTOs.AccountsDTO;
using Application.Features.Accounts.Requests.Queries;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Accounts.Handlers.Queries
{
    public class GetAllAccountsRequestHandler : IRequestHandler<GetAllAccountsRequest, ICollection<GetAccountDTO>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public GetAllAccountsRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<ICollection<GetAccountDTO>> Handle(GetAllAccountsRequest request, CancellationToken cancellationToken)
		{
			var accounts = await _unitOfWork.AccountRepository.GetAllAsync() ?? throw new Exception("No Account found!");
			return _mapper.Map<ICollection<GetAccountDTO>>(accounts);
		}
	}
}
