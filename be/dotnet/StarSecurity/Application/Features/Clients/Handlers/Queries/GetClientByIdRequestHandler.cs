using Application.Contracts.Persistences;
using Application.DTOs.ClientsDTO;
using Application.Features.Clients.Requests.Queries;
using AutoMapper;
using MediatR;

namespace Application.Features.Clients.Handlers.Queries
{
    public class GetClientByIdRequestHandler : IRequestHandler<GetClientByIdRequest, GetClientDTO>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public GetClientByIdRequestHandler(
			IUnitOfWork unitOfWork,
			IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
		public async Task<GetClientDTO> Handle(GetClientByIdRequest request, CancellationToken cancellationToken)
		{
			var clients = await _unitOfWork.ClientRepository.GetByIdAsync(request.Id) ?? throw new Exception("No Client found!");
			return _mapper.Map<GetClientDTO>(clients);
		}
	}
}
