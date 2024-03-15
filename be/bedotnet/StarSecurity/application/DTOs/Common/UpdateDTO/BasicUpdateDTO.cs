using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.DTOs.Common.UpdateDTO
{
	public abstract class BasicUpdateDTO
	{
		[Required]
		public Guid Id { get; set; }
	}
}
