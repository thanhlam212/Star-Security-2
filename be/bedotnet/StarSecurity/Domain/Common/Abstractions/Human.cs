using domain.Common.Enums;
using domain.Common.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace domain.Common.Abstractions
{
    public abstract class Human : Entity
	{
		[Required(ErrorMessage = "{PropertyName} is required")]
		public Name Name { get; set; }
		[Required(ErrorMessage = "{PropertyName} is required")]
		public Gender Gender { get; set; }
		[Required(ErrorMessage = "{PropertyName} is required")]
		public DateTime DateOfBirth { get; set; }
		public string? Address { get; set; }
		[Required(ErrorMessage = "{PropertyName} is required")]
		[Phone]
		public string? ContactNumber { get; set; }
		[Required(ErrorMessage = "{PropertyName} is required")]
		[EmailAddress]
		public Email Email { get; set; }
		protected Human(Name name,
						Gender gender,
						string? address,
						string? contractNumber,
						Email email) : base()
		{
			Name = name;
			Gender = gender;
			Address = address;
			ContactNumber = contractNumber;
			Email = email;
		}
	}
}
