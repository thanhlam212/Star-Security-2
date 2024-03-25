using Application.DTOs.AccountsDTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Accounts.Requests.Queries
{
	public class GetAccountByEmailRequest : IRequest<GetDetailAccountDTO>
	{
		public string Email { get; set; }
	}
}
