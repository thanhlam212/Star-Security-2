using domain.Common.Enums;
using domain.Common.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.DTOs.Common.CreateDTO
{
    public abstract class HumanCreateDTO : BasicCreateDTO
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
		public Email EmailAdress { get; protected set; }
	}
}
