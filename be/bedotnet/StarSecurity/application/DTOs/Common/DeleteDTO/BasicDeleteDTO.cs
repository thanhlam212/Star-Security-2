﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.DTOs.Common.DeleteDTO
{
	public abstract class BasicDeleteDTO
	{
		[Required(ErrorMessage = "{PropertyName} is required")]
		public Guid Id { get; set; }
	}
}