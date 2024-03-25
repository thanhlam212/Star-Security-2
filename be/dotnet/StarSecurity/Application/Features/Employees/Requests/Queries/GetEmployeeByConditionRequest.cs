using Application.Features.Employees.Requests.Queries.Common;

using MediatR;

namespace Application.Features.Employees.Requests.Queries
{
	public class GetEmployeeByIdRequest : GetSingleEmployeeRequest
	{
		public Guid Id { get; set; }
	}
	public class GetEmployeeByEmailRequest : GetSingleEmployeeRequest
	{
		public string Email { get; set; }
	}
	public class GetEmployeeByEmployeeCodeRequest : GetSingleEmployeeRequest
	{
		public string EmployeeCode { get; set; }
	}
}
