using Application.Contracts.Persistences;
using Application.DTOs.ClientsDTO;
using Application.Features.Clients.Requests.Queries;
using AutoMapper;
using MediatR;

namespace Application.Features.Clients.Handlers.Queries
{
    public class GetClientByGenderRequestHandler : IRequestHandler<GetClientByGenderRequest, ICollection<GetClientDTO>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public GetClientByGenderRequestHandler(
			IUnitOfWork unitOfWork,
			IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
		public async Task<ICollection<GetClientDTO>> Handle(GetClientByGenderRequest request, CancellationToken cancellationToken)
		{
			var clients = await _unitOfWork.ClientRepository.GetByGenderAsync(request.Gender) ?? throw new Exception("No Client found!");
			return _mapper.Map<ICollection<GetClientDTO>>(clients);
		}
	}
}
