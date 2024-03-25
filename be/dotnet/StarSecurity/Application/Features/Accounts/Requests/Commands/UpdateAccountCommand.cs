using Application.DTOs.AccountsDTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Accounts.Requests.Commands
{
	public class UpdateAccountCommand : IRequest<Unit> //Unit means return nothing => void type
	{
		public UpdateAccountDTO UpdateAccountDTO { get; set; }

	}
}
