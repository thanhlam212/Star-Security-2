using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Auth
{
	public class LoginRequestDTO
	{
		[Required(ErrorMessage = "{PropertyName} is required")]
		public string Email { get; protected set; }
		[Required(ErrorMessage = "{PropertyName} is required")]
		public string PasswordHash { get; protected set; }
	}
}
