using application.Contracts.Persistences;
using application.DTOs.AccountsDTO;
using application.DTOs.ClientsDTO;
using application.Features.Clients.Requests.Queries;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Features.Clients.Handlers.Queries
{
    public class GetAllClientRequestHandler : IRequestHandler<GetAllClientRequest, ICollection<GetClientDTO>>
	{
		private readonly IClientRepository _clientRepository;
		private readonly IMapper _mapper;

		public GetAllClientRequestHandler(
			IClientRepository clientRepository,
			IMapper mapper)
		{
			_clientRepository = clientRepository;
			_mapper = mapper;
		}
		public async Task<ICollection<GetClientDTO>> Handle(GetAllClientRequest request, CancellationToken cancellationToken)
		{
			var clients = await _clientRepository.GetAllAsync() ?? throw new Exception("No Client found!");
			return _mapper.Map<ICollection<GetClientDTO>>(clients);
		}
	}
}
