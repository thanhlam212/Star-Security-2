using application.DTOs.Common.GetDTO;
using domain.Common.Enums;
using domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.DTOs.EmployeesDTO
{
	public class GetEmployeeDTO : HumanGetDTO
	{
		public string EmployeeCode { get; protected set; }
		public string EducationalQualification { get; protected set; }
		public Role Role { get; protected set; }
		public string Grade { get; protected set; }
		public string? Achievements { get; protected set; }
		public ProvideService ProvideService { get; protected set; }
		public Branch Branch { get; protected set; }
		public Offer? Offer { get; protected set; }
	}
}
