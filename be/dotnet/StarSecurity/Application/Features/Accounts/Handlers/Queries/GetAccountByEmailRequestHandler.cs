using Application.Contracts.Persistences;
using Application.DTOs.AccountsDTO;
using Application.Features.Accounts.Requests.Queries;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Accounts.Handlers.Queries
{
    public class GetAccountByEmailRequestHandler : IRequestHandler<GetAccountByEmailRequest, GetDetailAccountDTO>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public GetAccountByEmailRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
		public async Task<GetDetailAccountDTO> Handle(GetAccountByEmailRequest request, CancellationToken cancellationToken)
		{
			var account = await _unitOfWork.AccountRepository.GetByEmailAsync(request.Email) ?? throw new Exception("No Account found!");
			account.Employee = await _unitOfWork.EmployeeRepository.GetByIdAsync(account.EmployeeId);
			//return account;
			return _mapper.Map<GetDetailAccountDTO>(account);
		}
	}
}
