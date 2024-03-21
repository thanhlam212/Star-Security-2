using application.Contracts.Persistences;
using application.DTOs.ClientsDTO;
using application.DTOs.EmployeesDTO;
using application.Features.Employees.Requests.Queries.Common;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Features.Employees.Handlers.Queries
{
    public class GetAllEmployeeRequestHandler : IRequestHandler<GetAllEmployeeRequest, IEnumerable<GetEmployeeDTO>>
	{
		private readonly IEmployeeRepository _employeeRepository;
		private readonly IMapper _mapper;
		public GetAllEmployeeRequestHandler(
			IEmployeeRepository employeeRepository,
			IMapper mapper)
		{
			_employeeRepository = employeeRepository;
			_mapper = mapper;
		}
		public async Task<IEnumerable<GetEmployeeDTO>> Handle(GetAllEmployeeRequest request, CancellationToken cancellationToken)
		{
			var employees = await _employeeRepository.GetAllAsync() ?? throw new Exception("No Employee found!");
			return _mapper.Map<ICollection<GetEmployeeDTO>>(employees);
		}
	}
}
