using application.Contracts.Persistences;
using application.DTOs.EmployeesDTO;
using application.Features.Employees.Requests.Queries;
using application.Features.Employees.Requests.Queries.Common;
using AutoMapper;
using domain.Entities;
using MediatR;

namespace application.Features.Employees.Handlers.Queries
{
    public class GetListEmployeeByConditionRequestHandler : IRequestHandler<GetAllEmployeeRequest, IEnumerable<GetEmployeeDTO>>
	{
		private readonly IEmployeeRepository _employeeRepository;
		private readonly IMapper _mapper;
		public GetListEmployeeByConditionRequestHandler(
			IEmployeeRepository employeeRepository,
			IMapper mapper)
		{
			_employeeRepository = employeeRepository;
			_mapper = mapper;
		}
		public async Task<IEnumerable<GetEmployeeDTO>> Handle(GetAllEmployeeRequest request, CancellationToken cancellationToken)
		{
			IEnumerable<Employee> employees = null;

			if (request is GetListEmployeeByGenderRequest byGenderRequest)
			{
				employees = await _employeeRepository.GetByGenderAsync(byGenderRequest.Gender);
			}
			else if (request is GetListEmployeeByBranchIdRequest byBranchIdRequest)
			{
				employees = await _employeeRepository.GetByBranchIdAsync(byBranchIdRequest.BranchId);
			}
			else if (request is GetListEmployeeByNameRequest byNameRequest)
			{
				employees = await _employeeRepository.GetByNameAsync(byNameRequest.Name);
			}
			else if (request is GetListEmployeeByProvideServiceRequest byProvideServiceRequest)
			{
				employees = await _employeeRepository.GetByProvideServiceAsync(byProvideServiceRequest.ProvideService);
			}
			else if (request is GetListEmployeeByRoleRequest byRoleRequest)
			{
				employees = await _employeeRepository.GetByRoleAsync(byRoleRequest.Role);
			}
			else if (request is GetListEmployeeByYearOfBirthRequest byYearOfBirthRequest)
			{
				employees = await _employeeRepository.GetByYearOfBirthAsync(byYearOfBirthRequest.YearOfBirth);
			}
			else
			{
				return null;
			}

			return _mapper.Map<ICollection<GetEmployeeDTO>>(employees);
		}
	}
}
