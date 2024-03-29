﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Common.UpdateDTO
{
    public abstract class HumanUpdateDTO : BasicUpdateDTO
	{
		[Required(ErrorMessage = "{PropertyName} is required")]
		public string Name { get; set; }
		[Required(ErrorMessage = "{PropertyName} is required")]
		public string Gender { get; set; }
		[Required(ErrorMessage = "{PropertyName} is required")]
		public DateTime DateOfBirth { get; set; }
		public string? Address { get; set; }
		[Required(ErrorMessage = "{PropertyName} is required")]
		[Phone]
		public string ContactNumber { get; set; }
		[Required(ErrorMessage = "{PropertyName} is required")]
		[EmailAddress]
		public string Email { get; set; }
	}
}
