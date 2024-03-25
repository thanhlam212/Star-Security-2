using Application.DTOs.ClientsDTO;

using MediatR;

namespace Application.Features.Clients.Requests.Queries
{
	public class GetClientByNameRequest : IRequest<ICollection<GetClientDTO>>
	{
		public string Name { get; set; }
	}
}
