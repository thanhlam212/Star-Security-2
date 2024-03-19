using application.DTOs.ClientsDTO;
using domain.Common.ValueObjects;
using MediatR;

namespace application.Features.Clients.Requests.Queries
{
	public class GetClientByEmailRequest : IRequest<GetClientDTO>
	{
		public Email Email { get; set; }
	}
}
