using Application.Contracts.Persistences;
using Application.DTOs.EmployeesDTO;
using Application.Features.Employees.Requests.Queries;
using Application.Features.Employees.Requests.Queries.Common;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Employees.Handlers.Queries
{
    public class GetListEmployeeByConditionRequestHandler : IRequestHandler<GetAllEmployeeRequest, IEnumerable<GetEmployeeDTO>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		public GetListEmployeeByConditionRequestHandler(
			IUnitOfWork unitOfWork,
			IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
		public async Task<IEnumerable<GetEmployeeDTO>> Handle(GetAllEmployeeRequest request, CancellationToken cancellationToken)
		{
			IEnumerable<Employee> employees = null;

			if (request is GetListEmployeeByGenderRequest byGenderRequest)
			{
				employees = await _unitOfWork.EmployeeRepository.GetByGenderAsync(byGenderRequest.Gender);
			}
			else if (request is GetListEmployeeByBranchIdRequest byBranchIdRequest)
			{
				employees = await _unitOfWork.EmployeeRepository.GetByBranchIdAsync(byBranchIdRequest.BranchId);
			}
			else if (request is GetListEmployeeByNameRequest byNameRequest)
			{
				employees = await _unitOfWork.EmployeeRepository.GetByNameAsync(byNameRequest.Name);
			}
			else if (request is GetListEmployeeByProvideServiceRequest byProvideServiceRequest)
			{
				employees = await _unitOfWork.EmployeeRepository.GetByProvideServiceAsync(byProvideServiceRequest.ProvideService);
			}
			else if (request is GetListEmployeeByRoleRequest byRoleRequest)
			{
				employees = await _unitOfWork.EmployeeRepository.GetByRoleAsync(byRoleRequest.Role);
			}
			else if (request is GetListEmployeeByYearOfBirthRequest byYearOfBirthRequest)
			{
				employees = await _unitOfWork.EmployeeRepository.GetByYearOfBirthAsync(byYearOfBirthRequest.YearOfBirth);
			}
			else
			{
				return null;
			}

			return _mapper.Map<ICollection<GetEmployeeDTO>>(employees);
		}
	}
}
