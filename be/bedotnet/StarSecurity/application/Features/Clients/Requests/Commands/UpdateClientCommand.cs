using application.DTOs.ClientsDTO;
using MediatR;

namespace application.Features.Clients.Requests.Commands
{
	public class UpdateClientCommand : IRequest<Unit>
	{
		public UpdateClientDTO UpdateClientDTO { get; set; }
	}
}
