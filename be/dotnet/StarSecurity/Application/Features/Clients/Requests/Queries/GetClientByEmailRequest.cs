using Application.DTOs.ClientsDTO;
using MediatR;

namespace Application.Features.Clients.Requests.Queries
{
	public class GetClientByEmailRequest : IRequest<GetClientDTO>
	{
		public string Email { get; set; }
	}
}
