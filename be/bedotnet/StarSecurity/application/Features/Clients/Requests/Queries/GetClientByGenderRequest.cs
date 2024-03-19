using application.DTOs.ClientsDTO;
using domain.Common.Enums;
using MediatR;

namespace application.Features.Clients.Requests.Queries
{
	public class GetClientByGenderRequest : IRequest<ICollection<GetClientDTO>>
	{
		public Gender Gender { get; set; }
	}
}
