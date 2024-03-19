using application.DTOs.ClientsDTO;
using domain.Common.ValueObjects;
using MediatR;

namespace application.Features.Clients.Requests.Queries
{
	public class GetClientByNameRequest : IRequest<ICollection<GetClientDTO>>
	{
		public Name Name { get; set; }
	}
}
