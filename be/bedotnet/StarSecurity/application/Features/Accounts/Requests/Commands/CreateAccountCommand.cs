using application.DTOs.AccountsDTO;
using domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Features.Accounts.Requests.Commands
{
	public class CreateAccountCommand : IRequest<Guid> //must have a look later what will return, here only return the Id of account new created
	{
		public CreateAccountDTO CreateAccountDTO { get; set; }
	}
}
