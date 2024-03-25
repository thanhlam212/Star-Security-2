using Application.DTOs.Common.CreateDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.BranchesDTO
{
	public class CreateBranchDTO : BasicCreateDTO
	{
		[Required(ErrorMessage = "{PropertyName} is required")]
		public string Name { get; set; }
		[Required(ErrorMessage = "{PropertyName} is required")]
		public string Region { get; set; }
		[Required(ErrorMessage = "{PropertyName} is required")]
		public string ContactDetail { get; set; }
	}
}
