using application.DTOs.ClientsDTO;
using application.Features.Clients.Requests.Queries;
using application.Persistences.Contracts;
using AutoMapper;
using MediatR;

namespace application.Features.Clients.Handlers.Queries
{
	public class GetClientByNameRequestHandler : IRequestHandler<GetClientByNameRequest, ICollection<GetClientDTO>>
	{
		private readonly IClientRepository _clientRepository;
		private readonly IMapper _mapper;

		public GetClientByNameRequestHandler(
			IClientRepository clientRepository,
			IMapper mapper)
		{
			_clientRepository = clientRepository;
			_mapper = mapper;
		}
		public async Task<ICollection<GetClientDTO>> Handle(GetClientByNameRequest request, CancellationToken cancellationToken)
		{
			var clients = await _clientRepository.GetByNameAsync(request.Name) ?? throw new Exception("No Account found!");
			return _mapper.Map<ICollection<GetClientDTO>>(clients);
		}
	}
}
