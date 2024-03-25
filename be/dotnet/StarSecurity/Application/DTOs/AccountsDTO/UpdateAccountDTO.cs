using Application.DTOs.Common.UpdateDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.AccountsDTO
{
	public class UpdateAccountDTO : BasicUpdateDTO
	{
		[Required(ErrorMessage = "{PropertyName} is required")]
		public string Email { get; set; }
		[Required(ErrorMessage = "{PropertyName} is required")]
		public string PasswordHash { get; set; }
		[Required(ErrorMessage = "{PropertyName} is required")]
		public Guid EmployeeId { get; set; }
	}
}
