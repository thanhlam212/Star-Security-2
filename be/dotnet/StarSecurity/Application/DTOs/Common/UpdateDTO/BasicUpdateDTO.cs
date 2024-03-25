using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Common.UpdateDTO
{
	public abstract class BasicUpdateDTO
	{
		[Required(ErrorMessage = "{PropertyName} is required")]
		public Guid Id { get; set; }
	}
}
