using application.DTOs.Common.CreateDTO;
using domain.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.DTOs.BranchesDTO
{
	public class CreateBranchDTO : BasicCreateDTO
	{
		[Required(ErrorMessage = "{PropertyName} is required")]
		public string Name { get; set; }
		[Required(ErrorMessage = "{PropertyName} is required")]
		public Region Region { get; set; }
		[Required(ErrorMessage = "{PropertyName} is required")]
		public string ContactDetail { get; set; }
		public Guid? Manager { get; set; }
	}
}
