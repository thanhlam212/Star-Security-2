using application.DTOs.ClientsDTO;
using application.Features.Clients.Requests.Queries;
using application.Persistences.Contracts;
using AutoMapper;
using MediatR;

namespace application.Features.Clients.Handlers.Queries
{
	public class GetClientByEmailRequestHandler : IRequestHandler<GetClientByEmailRequest, GetClientDTO>
	{
		private readonly IClientRepository _clientRepository;
		private readonly IMapper _mapper;

		public GetClientByEmailRequestHandler(
			IClientRepository clientRepository,
			IMapper mapper)
		{
			_clientRepository = clientRepository;
			_mapper = mapper;
		}
		public async Task<GetClientDTO> Handle(GetClientByEmailRequest request, CancellationToken cancellationToken)
		{
			var client = await _clientRepository.GetByEmailAsync(request.Email) ?? throw new Exception("No Account found!");
			return _mapper.Map<GetClientDTO>(client);
		}
	}
}
