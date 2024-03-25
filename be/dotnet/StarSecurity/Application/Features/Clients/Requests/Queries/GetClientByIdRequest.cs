using Application.DTOs.ClientsDTO;
using MediatR;

namespace Application.Features.Clients.Requests.Queries
{
	public class GetClientByIdRequest : IRequest<GetClientDTO>
	{
		public Guid Id { get; set; }
	}
}
