using Application.DTOs.ClientsDTO;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Features.Clients.Requests.Queries
{
	public class GetAllClientRequest : IRequest<ICollection<GetClientDTO>>
	{

	}
}
