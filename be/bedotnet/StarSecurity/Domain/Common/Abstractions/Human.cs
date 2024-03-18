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
		[Required]
		public Name Name { get; protected set; }
		[Required]
		public Gender Gender { get; protected set; }
		public string? Address { get; protected set; }
		[Phone]
		public string? ContactNumber { get; protected set; }
		[Required]
		[EmailAddress]
		public Email Email { get; protected set; }
		protected Human(Name name,
						Gender gender,
						string address,
						string contractNumber,
						Email email)
		{
			Name = name;
			Gender = gender;
			Address = address;
			ContactNumber = contractNumber;
			Email = email;
		}
	}
}
