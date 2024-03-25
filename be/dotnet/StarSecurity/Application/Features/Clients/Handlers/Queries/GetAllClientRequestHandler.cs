using Application.Contracts.Persistences;
using Application.DTOs.ClientsDTO;
using Application.Features.Clients.Requests.Queries;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Clients.Handlers.Queries
{
    public class GetAllClientRequestHandler : IRequestHandler<GetAllClientRequest, ICollection<GetClientDTO>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public GetAllClientRequestHandler(
			IUnitOfWork unitOfWork,
			IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
		public async Task<ICollection<GetClientDTO>> Handle(GetAllClientRequest request, CancellationToken cancellationToken)
		{
			var clients = await _unitOfWork.ClientRepository.GetAllAsync() ?? throw new Exception("No Client found!");
			return _mapper.Map<ICollection<GetClientDTO>>(clients);
		}
	}
}
