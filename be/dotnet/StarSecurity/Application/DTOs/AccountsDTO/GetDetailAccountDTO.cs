using Application.DTOs.Common.GetDTO;
using Domain.Entities;

namespace Application.DTOs.AccountsDTO
{
	public class GetDetailAccountDTO : BasicGetDTO
	{
		public string Email { get; set; }
		public string PasswordHash { get; set; }
		public Employee Employee { get; set; }
	}
}
