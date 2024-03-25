using Application.DTOs.ClientsDTO;
using MediatR;

namespace Application.Features.Clients.Requests.Queries
{
	public class GetClientByYearOfBirthRequest : IRequest<ICollection<GetClientDTO>>
	{
		public int YearOfBirth { get; set; }
	}
}
