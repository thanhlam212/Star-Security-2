using application.DTOs.ClientsDTO;
using MediatR;

namespace application.Features.Clients.Requests.Queries
{
	public class GetClientByYearOfBirthRequest : IRequest<ICollection<GetClientDTO>>
	{
		public int YearOfBirth { get; set; }
	}
}
