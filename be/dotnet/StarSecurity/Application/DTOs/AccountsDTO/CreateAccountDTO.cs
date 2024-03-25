using Application.DTOs.Common.CreateDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.AccountsDTO
{
	public class CreateAccountDTO : BasicCreateDTO
	{
		[Required(ErrorMessage = "{PropertyName} is required")]
		[EmailAddress] 
		public string Email { get; set; }
		[Required(ErrorMessage = "{PropertyName} is required")]
		public string PasswordHash { get; set; }
		[Required(ErrorMessage = "{PropertyName} is required")]
		public Guid EmployeeId { get; set; }
	}
}
