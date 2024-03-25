using Application.Contracts.Persistences;
using Application.DTOs.AccountsDTO;
using Application.DTOs.BranchesDTO;
using Application.Features.Accounts.Requests.Queries;
using Application.Features.Branches.Requests.Queries;
using AutoMapper;
using MediatR;

namespace Application.Features.Branches.Handlers.Queries
{
	public class GetAllBranchesRequestHandler : IRequestHandler<GetAllBranchesRequest, ICollection<GetBranchDTO>>
    {
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

        public GetAllBranchesRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
			_unitOfWork = unitOfWork;
			_mapper = mapper;
        }

        public async Task<ICollection<GetBranchDTO>> Handle(GetAllBranchesRequest request, CancellationToken cancellationToken)
        {
            var branches = await _unitOfWork.BranchRepository.GetAllAsync() ?? throw new Exception("No Branch found!");
            return _mapper.Map<ICollection<GetBranchDTO>>(branches);
        }
    }
}
