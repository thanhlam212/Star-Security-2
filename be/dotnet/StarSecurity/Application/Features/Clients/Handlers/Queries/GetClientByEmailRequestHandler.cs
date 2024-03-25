using Application.Contracts.Persistences;
using Application.DTOs.ClientsDTO;
using Application.Features.Clients.Requests.Queries;
using AutoMapper;
using MediatR;

namespace Application.Features.Clients.Handlers.Queries
{
    public class GetClientByEmailRequestHandler : IRequestHandler<GetClientByEmailRequest, GetClientDTO>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public GetClientByEmailRequestHandler(
			IUnitOfWork unitOfWork,
			IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
		public async Task<GetClientDTO> Handle(GetClientByEmailRequest request, CancellationToken cancellationToken)
		{
			var client = await _unitOfWork.ClientRepository.GetByEmailAsync(request.Email) ?? throw new Exception("No Client found!");
			return _mapper.Map<GetClientDTO>(client);
		}
	}
}
