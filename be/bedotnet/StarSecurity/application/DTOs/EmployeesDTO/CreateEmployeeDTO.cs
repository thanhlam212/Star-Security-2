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
		[Required]
		public string EmployeeCode { get; protected set; }
		[Required]
		public string EducationalQualification { get; protected set; }
		[Required]
		public Role Role { get; protected set; }
		[Required]
		public string Grade { get; protected set; }
		public string? Achievements { get; protected set; }
		[Required]
		public ProvideService ProvideService { get; protected set; }
		[Required]
		public Guid BranchId { get; protected set; }
		public Guid? CurrentOffer { get; protected set; }
	}
}
