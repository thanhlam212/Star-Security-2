using domain.Common.Enums;
using domain.Common.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.DTOs.Common.UpdateDTO
{
    public abstract class HumanUpdateDTO : BasicUpdateDTO
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
	}
}
