using domain.Common.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.DTOs.Auth
{
	public class LoginRequestDTO
	{
		[Required]
		public Email Email { get; protected set; }
		[Required]
		public string PasswordHash { get; protected set; }
	}
}
