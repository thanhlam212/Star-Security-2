using application.DTOs.Common.CreateDTO;
using domain.Common.Enums;
using domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.DTOs.EmployeesDTO
{
	public class CreateEmployeeDTO : HumanCreateDTO
	{
		[Required(ErrorMessage = "{PropertyName} is required")]
		public string EmployeeCode { get; set; }
		[Required(ErrorMessage = "{PropertyName} is required")]
		public string EducationalQualification { get; set; }
		[Required(ErrorMessage = "{PropertyName} is required")]
		public Role Role { get;	set; }
		[Required(ErrorMessage = "{PropertyName} is required")]
		public string Grade { get; set; }
		public string? Achievements { get; set; }
		[Required(ErrorMessage = "{PropertyName} is required")]
		public ProvideService ProvideService { get;	set; }
		[Required(ErrorMessage = "{PropertyName} is required")]
		public Guid BranchId { get; set; }
		public Guid? CurrentOfferId { get; set; }
	}
}
