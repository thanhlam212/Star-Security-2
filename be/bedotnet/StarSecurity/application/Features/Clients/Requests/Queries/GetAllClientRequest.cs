using application.DTOs.ClientsDTO;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace application.Features.Clients.Requests.Queries
{
	public class GetAllClientRequest : IRequest<ICollection<GetClientDTO>>
	{

	}
}
