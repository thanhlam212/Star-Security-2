using Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
	public class Employee : Human
	{
		[Required(ErrorMessage = "{PropertyName} is required")]
		public string EmployeeCode { get; set; }
		[Required(ErrorMessage = "{PropertyName} is required")]
		public string EducationalQualification { get; set; }
		[Required(ErrorMessage = "{PropertyName} is required")]
		public string Role { get; set; }
		[Required(ErrorMessage = "{PropertyName} is required")]
		public string Grade { get; set; }
		public string? Achievements { get; set; }
		[Required(ErrorMessage = "{PropertyName} is required")]
		public string ProvideService { get; set; }

		//n-1 with Branch
		[Required(ErrorMessage = "{PropertyName} is required")]
		public Guid BranchId { get; set; }
		[ForeignKey("BranchId")]
		public Branch Branch { get; set; }

		// Offer
		public Guid? CurrentOfferId { get; set; }
		public virtual ICollection<Offer>? Offers { get; set; }
		public Employee(
			string name,
			string gender,
			DateTime dateOfBirth,
			string? address,
			string? contactNumber,
			string email,
			string employeeCode,
			string educationalQualification,
			string role,
			string grade,
			string provideService,
			Guid branchId,
			Guid? currentOfferId)
			: base(name,
				  gender,
				  dateOfBirth,
				  address,
				  contactNumber,
				  email)
		{
			EmployeeCode = employeeCode;
			EducationalQualification = educationalQualification;
			Role = role;
			Grade = grade;
			ProvideService = provideService;
			BranchId = branchId;
			CurrentOfferId = currentOfferId;
		}
	}
}
