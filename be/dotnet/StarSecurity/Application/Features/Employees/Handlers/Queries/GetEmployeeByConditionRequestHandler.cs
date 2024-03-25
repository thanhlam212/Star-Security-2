using Application.Contracts.Persistences;
using Application.DTOs.EmployeesDTO;
using Application.Features.Employees.Requests.Queries;
using Application.Features.Employees.Requests.Queries.Common;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Employees.Handlers.Queries
{
    public class GetEmployeeByConditionRequestHandler : IRequestHandler<GetSingleEmployeeRequest, GetEmployeeDTO>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		public GetEmployeeByConditionRequestHandler(
			IUnitOfWork unitOfWork,
			IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
		public async Task<GetEmployeeDTO> Handle(GetSingleEmployeeRequest request, CancellationToken cancellationToken)
		{
			Employee employee;

			if (request is GetEmployeeByIdRequest byIdRequest)
			{
				employee = await _unitOfWork.EmployeeRepository.GetByIdAsync(byIdRequest.Id);
			}
			else if (request is GetEmployeeByEmailRequest byEmailRequest)
			{
				employee = await _unitOfWork.EmployeeRepository.GetByEmailAsync(byEmailRequest.Email);
			}
			else if (request is GetEmployeeByEmployeeCodeRequest byEmployeeCodeRequest)
			{
				employee = await _unitOfWork.EmployeeRepository.GetByEmployeeCodeAsync(byEmployeeCodeRequest.EmployeeCode);
			}
			else
			{
				// Nếu không có điều kiện tìm kiếm, trả về null
				return null;
			}

			return _mapper.Map<GetEmployeeDTO>(employee);
		}
	}
}
