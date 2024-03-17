using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Features.Accounts.Requests.Commands
{
	public class DeleteAccountCommand : IRequest<Unit>
	{
		public Guid Id { get; set; }
	}
}
