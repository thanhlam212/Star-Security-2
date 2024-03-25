using Application.Contracts.Persistences;
using Application.DTOs.ClientsDTO;
using Application.DTOs.EmployeesDTO;
using Application.Features.Employees.Requests.Queries.Common;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Employees.Handlers.Queries
{
    public class GetAllEmployeeRequestHandler : IRequestHandler<GetAllEmployeeRequest, IEnumerable<GetEmployeeDTO>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		public GetAllEmployeeRequestHandler(
			IUnitOfWork unitOfWork,
			IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
		public async Task<IEnumerable<GetEmployeeDTO>> Handle(GetAllEmployeeRequest request, CancellationToken cancellationToken)
		{
			var employees = await _unitOfWork.EmployeeRepository.GetAllAsync() ?? throw new Exception("No Employee found!");
			return _mapper.Map<ICollection<GetEmployeeDTO>>(employees);
		}
	}
}
