using MediatR;

namespace application.Features.Clients.Requests.Commands
{
	public class DeleteClientCommand : IRequest<Unit>
	{
		public Guid Id { get; set; }
	}
}
