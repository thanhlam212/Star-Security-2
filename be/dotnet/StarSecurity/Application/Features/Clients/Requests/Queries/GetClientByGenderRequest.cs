using Application.DTOs.ClientsDTO;
using MediatR;

namespace Application.Features.Clients.Requests.Queries
{
	public class GetClientByGenderRequest : IRequest<ICollection<GetClientDTO>>
	{
		public string Gender { get; set; }
	}
}
