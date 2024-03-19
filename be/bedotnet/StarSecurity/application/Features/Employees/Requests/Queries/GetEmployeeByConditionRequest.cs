using application.DTOs.EmployeesDTO;
using application.Features.Employees.Requests.Queries.Common;
using domain.Common.ValueObjects;
using MediatR;

namespace application.Features.Employees.Requests.Queries
{
	public class GetEmployeeByIdRequest : GetSingleEmployeeRequest
	{
		public Guid Id { get; set; }
	}
	public class GetEmployeeByEmailRequest : GetSingleEmployeeRequest
	{
		public Email Email { get; set; }
	}
	public class GetEmployeeByEmployeeCodeRequest : GetSingleEmployeeRequest
	{
		public string EmployeeCode { get; set; }
	}
}
