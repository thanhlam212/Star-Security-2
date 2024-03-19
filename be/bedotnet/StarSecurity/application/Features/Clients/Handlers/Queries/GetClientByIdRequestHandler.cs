using application.DTOs.ClientsDTO;
using application.Features.Clients.Requests.Queries;
using application.Persistences.Contracts;
using AutoMapper;
using MediatR;

namespace application.Features.Clients.Handlers.Queries
{
	public class GetClientByIdRequestHandler : IRequestHandler<GetClientByIdRequest, GetClientDTO>
	{
		private readonly IClientRepository _clientRepository;
		private readonly IMapper _mapper;

		public GetClientByIdRequestHandler(
			IClientRepository clientRepository,
			IMapper mapper)
		{
			_clientRepository = clientRepository;
			_mapper = mapper;
		}
		public async Task<GetClientDTO> Handle(GetClientByIdRequest request, CancellationToken cancellationToken)
		{
			var clients = await _clientRepository.GetByIdAsync(request.Id) ?? throw new Exception("No Account found!");
			return _mapper.Map<GetClientDTO>(clients);
		}
	}
}
