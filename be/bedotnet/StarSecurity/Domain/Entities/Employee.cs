using domain.Common.Abstractions;
using domain.Common.Enums;
using domain.Common.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace domain.Entities
{
	public class Employee(Name name,
		Gender gender,
		string? contractNumber,
		string? address,
		Email email,
		string employeeCode,
		string educationalQualification,
		Role role,
		string grade,
		string achievements,
		ProvideService provideService,
		Guid branchId,
		Guid? currentOfferId)
		: Human(name,
			  gender,
			  contractNumber,
			  address,
			  email)
	{
		[Required(ErrorMessage = "{PropertyName} is required")]
		public string EmployeeCode { get; set; } = employeeCode;
		[Required(ErrorMessage = "{PropertyName} is required")]
		public string EducationalQualification { get; set; } = educationalQualification;
		[Required(ErrorMessage = "{PropertyName} is required")]
		public Role Role { get; set; } = role;
		[Required(ErrorMessage = "{PropertyName} is required")]
		public string Grade { get; set; } = grade;
		public string? Achievements { get; set; } = achievements;
		[Required(ErrorMessage = "{PropertyName} is required")]
		public ProvideService ProvideService { get; set; } = provideService;

		//n-1 with Branch
		[Required(ErrorMessage = "{PropertyName} is required")]
		public Guid BranchId { get; set; } = branchId;
		public Branch? Branch { get; set; }

		//1-n with Offer
		public virtual ICollection<Offer>? Offers { get; set; } //1-n relationship
		public Guid? CurrentOfferId { get; set; } = currentOfferId;
		public virtual Offer? CurrentOffer { get; set; } // hold the current offer
	}
}

