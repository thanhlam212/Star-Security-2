using application.DTOs.EmployeesDTO;
using application.Features.Employees.Requests.Queries;
using application.Features.Employees.Requests.Queries.Common;
using application.Persistences.Contracts;
using AutoMapper;
using domain.Entities;
using MediatR;

namespace application.Features.Employees.Handlers.Queries
{
	public class GetEmployeeByConditionRequestHandler : IRequestHandler<GetSingleEmployeeRequest, GetEmployeeDTO>
	{
		private readonly IEmployeeRepository _employeeRepository;
		private readonly IMapper _mapper;
		public GetEmployeeByConditionRequestHandler(
			IEmployeeRepository employeeRepository,
			IMapper mapper)
		{
			_employeeRepository = employeeRepository;
			_mapper = mapper;
		}
		public async Task<GetEmployeeDTO> Handle(GetSingleEmployeeRequest request, CancellationToken cancellationToken)
		{
			Employee employee;

			if (request is GetEmployeeByIdRequest byIdRequest)
			{
				employee = await _employeeRepository.GetByIdAsync(byIdRequest.Id);
			}
			else if (request is GetEmployeeByEmailRequest byEmailRequest)
			{
				employee = await _employeeRepository.GetByEmailAsync(byEmailRequest.Email);
			}
			else if (request is GetEmployeeByEmployeeCodeRequest byEmployeeCodeRequest)
			{
				employee = await _employeeRepository.GetByEmployeeCodeAsync(byEmployeeCodeRequest.EmployeeCode);
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
