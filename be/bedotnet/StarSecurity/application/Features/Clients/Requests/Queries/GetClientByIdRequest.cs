using application.DTOs.ClientsDTO;
using MediatR;

namespace application.Features.Clients.Requests.Queries
{
	public class GetClientByIdRequest : IRequest<GetClientDTO>
	{
		public Guid Id { get; set; }
	}
}
