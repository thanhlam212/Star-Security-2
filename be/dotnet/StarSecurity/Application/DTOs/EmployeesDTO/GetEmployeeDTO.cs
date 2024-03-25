using Application.DTOs.Common.GetDTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.EmployeesDTO
{
	public class GetEmployeeDTO : HumanGetDTO
	{
		public string EmployeeCode { get; protected set; }
		public string EducationalQualification { get; protected set; }
		public string Role { get; protected set; }
		public string Grade { get; protected set; }
		public string? Achievements { get; protected set; }
		public string ProvideService { get; protected set; }
		public Guid BranchId { get; protected set; }
		public Guid? CurrentOfferId { get; protected set; }
	}
}
