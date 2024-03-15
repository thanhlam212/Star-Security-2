using application.DTOs.AccountsDTO;
using domain.Common.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Features.Accounts.Requests.Queries
{
	public class GetAccountByEmailRequest : IRequest<List<GetAccountDTO>>
	{
		public Email Email { get; set; }
	}
}
