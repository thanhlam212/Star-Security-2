using application.DTOs.ClientsDTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Features.Clients.Requests.Commands
{
	public class CreateClientCommand : IRequest<Guid>
	{
		public CreateClientDTO CreateClientDTO { get; set; }
	}
}
