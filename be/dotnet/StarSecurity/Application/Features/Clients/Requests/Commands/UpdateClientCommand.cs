using Application.DTOs.ClientsDTO;
using MediatR;

namespace Application.Features.Clients.Requests.Commands
{
	public class UpdateClientCommand : IRequest<Unit>
	{
		public UpdateClientDTO UpdateClientDTO { get; set; }
	}
}
