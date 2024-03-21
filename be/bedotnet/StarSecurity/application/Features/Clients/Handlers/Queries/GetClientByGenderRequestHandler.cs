using application.Contracts.Persistences;
using application.DTOs.ClientsDTO;
using application.Features.Clients.Requests.Queries;
using AutoMapper;
using MediatR;

namespace application.Features.Clients.Handlers.Queries
{
    public class GetClientByGenderRequestHandler : IRequestHandler<GetClientByGenderRequest, ICollection<GetClientDTO>>
	{
		private readonly IClientRepository _clientRepository;
		private readonly IMapper _mapper;

		public GetClientByGenderRequestHandler(
			IClientRepository clientRepository,
			IMapper mapper)
		{
			_clientRepository = clientRepository;
			_mapper = mapper;
		}
		public async Task<ICollection<GetClientDTO>> Handle(GetClientByGenderRequest request, CancellationToken cancellationToken)
		{
			var clients = await _clientRepository.GetByGenderAsync(request.Gender) ?? throw new Exception("No Client found!");
			return _mapper.Map<ICollection<GetClientDTO>>(clients);
		}
	}
}
