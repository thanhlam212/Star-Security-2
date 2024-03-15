using domain.Common.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.DTOs.Auth
{
	public class LoginRequestDTO
	{
		public Email Email { get; protected set; }
		public string PasswordHash { get; protected set; }
	}
}
