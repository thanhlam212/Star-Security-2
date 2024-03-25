using Application.Contracts.Persistences;
using Application.DTOs.BranchesDTO;
using Application.Features.Branches.Requests.Queries;
using AutoMapper;
using MediatR;

namespace Application.Features.Branches.Handlers.Queries
{
	public class GetBrancheByIdRequestHandler : IRequestHandler<GetBranchByIdRequest, GetBranchDTO>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public GetBrancheByIdRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
		public async Task<GetBranchDTO> Handle(GetBranchByIdRequest request, CancellationToken cancellationToken)
		{
			var branch = await _unitOfWork.BranchRepository.GetByIdAsync(request.Id) ?? throw new Exception("No Branch found!");
			return _mapper.Map<GetBranchDTO>(branch);
		}
	}
}
