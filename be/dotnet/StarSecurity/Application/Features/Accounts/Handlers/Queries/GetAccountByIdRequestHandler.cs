using Application.Contracts.Persistences;
using Application.DTOs.AccountsDTO;
using Application.Features.Accounts.Requests.Queries;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Accounts.Handlers.Queries
{
    public class GetAccountByIdRequestHandler : IRequestHandler<GetAccountByIdRequest, GetDetailAccountDTO>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public GetAccountByIdRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
		public async Task<GetDetailAccountDTO> Handle(GetAccountByIdRequest request, CancellationToken cancellationToken)
		{
			var account = await _unitOfWork.AccountRepository.GetByIdAsync(request.Id) ?? throw new Exception("No Account found!");
			account.Employee = await _unitOfWork.EmployeeRepository.GetByIdAsync(account.EmployeeId);
			return _mapper.Map<GetDetailAccountDTO>(account);
		}
	}
}
