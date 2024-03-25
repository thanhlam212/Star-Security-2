using Application.DTOs.Common.UpdateDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.BranchesDTO
{
    public class UpdateBranchDTO : BasicUpdateDTO
	{
		[Required(ErrorMessage = "{PropertyName} is required")]
		public string Name { get; set; }
		[Required(ErrorMessage = "{PropertyName} is required")]
		public string Region { get; set; }
		[Required(ErrorMessage = "{PropertyName} is required")]
		public string ContactDetail { get; set; }
	}
}
