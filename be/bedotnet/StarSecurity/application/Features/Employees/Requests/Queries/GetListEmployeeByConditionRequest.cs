using application.Features.Employees.Requests.Queries.Common;
using domain.Common.Enums;
using domain.Common.ValueObjects;
using MediatR;

namespace application.Features.Employees.Requests.Queries
{
	public class GetListEmployeeByGenderRequest : GetAllEmployeeRequest
	{		
		public Gender Gender { get; set; }		
	}
	public class GetListEmployeeByBranchIdRequest : GetAllEmployeeRequest
	{
		public Guid BranchId { get; set; }
	}
	public class GetListEmployeeByNameRequest : GetAllEmployeeRequest
	{
		public Name Name { get; set; }
	}
	public class GetListEmployeeByProvideServiceRequest : GetAllEmployeeRequest
	{
		public ProvideService ProvideService { get; set; }
	}
	public class GetListEmployeeByRoleRequest : GetAllEmployeeRequest
	{
		public Role Role { get; set; }
	}
	public class GetListEmployeeByYearOfBirthRequest : GetAllEmployeeRequest
	{
		public int YearOfBirth { get; set; }
	}
}
