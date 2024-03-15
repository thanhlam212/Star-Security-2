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
    public class Employee : Human
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

		//n-1 with Branch
		[Required]
        public Guid BranchId { get; protected set; }
        public Branch Branch { get; protected set; }

        //1-n with Offer
        public virtual ICollection<Offer> Offers { get; set; } //1-n relationship
        public Guid? OfferId { get; protected set; }
        public virtual Offer? CurrentOffer { get; protected set; } // hold the current offer

        // Constructor of Employee
        public Employee(Name name,
            Gender gender,
            string contractNumber,
            string address,
            Email email,
            string employeeCode,
            string educationalQualification,
            Role role,
            string grade,
            string achievements,
			ProvideService provideService,
			Branch branch,
            Offer currentOffer
            )
            : base(name,
                  gender,
                  contractNumber,
                  address,
                  email)
        {
            EmployeeCode = employeeCode;
            EducationalQualification = educationalQualification;
            Role = role;
            Grade = grade;
            Achievements = achievements;
            ProvideService = provideService;
			Branch = branch;
            CurrentOffer = currentOffer;
        }
    }
}

