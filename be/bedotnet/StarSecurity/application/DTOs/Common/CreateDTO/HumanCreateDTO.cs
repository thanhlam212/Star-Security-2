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
		[Required(ErrorMessage = "{PropertyName} is required")]
		public string Name { get; set; }
		[Required(ErrorMessage = "{PropertyName} is required")]
		public Gender Gender { get; set; }
		[Required(ErrorMessage = "{PropertyName} is required")]
		public DateTime DateOfBirth { get; set; }
		public string? Address { get; set; }
		public string? ContactNumber { get; set; }
		[Required(ErrorMessage = "{PropertyName} is required")]
		[EmailAddress]
		public string Email { get; set; }
	}
}
