using MediatR;

namespace Application.Features.Clients.Requests.Commands
{
	public class DeleteClientCommand : IRequest<Unit>
	{
		public Guid Id { get; set; }
	}
}
