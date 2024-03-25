using Application.Features.Employees.Requests.Queries.Common;

using MediatR;

namespace Application.Features.Employees.Requests.Queries
{
	public class GetListEmployeeByGenderRequest : GetAllEmployeeRequest
	{		
		public string Gender { get; set; }		
	}
	public class GetListEmployeeByBranchIdRequest : GetAllEmployeeRequest
	{
		public Guid BranchId { get; set; }
	}
	public class GetListEmployeeByNameRequest : GetAllEmployeeRequest
	{
		public string Name { get; set; }
	}
	public class GetListEmployeeByProvideServiceRequest : GetAllEmployeeRequest
	{
		public string ProvideService { get; set; }
	}
	public class GetListEmployeeByRoleRequest : GetAllEmployeeRequest
	{
		public string Role { get; set; }
	}
	public class GetListEmployeeByYearOfBirthRequest : GetAllEmployeeRequest
	{
		public int YearOfBirth { get; set; }
	}
}
