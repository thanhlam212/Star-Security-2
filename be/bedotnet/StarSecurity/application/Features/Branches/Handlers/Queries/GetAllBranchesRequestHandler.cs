using application.DTOs.BranchesDTO;
using application.Features.Branches.Requests.Queries;
using application.Persistences.Contracts;
using AutoMapper;
using MediatR;

namespace application.Features.Branches.Handlers.Queries
{
    public class GetAllBranchesRequestHandler : IRequestHandler<GetAllBranchesRequest, ICollection<GetBranchDTO>>
    {
        private readonly IBranchRepository _branchRepository;
        private readonly IMapper _mapper;

        public GetAllBranchesRequestHandler(IBranchRepository branchRepository, IMapper mapper)
        {
            _branchRepository = branchRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<GetBranchDTO>> Handle(GetAllBranchesRequest request, CancellationToken cancellationToken)
        {
            var branches = await _branchRepository.GetAllAsync() ?? throw new Exception("No Account found!");
            return _mapper.Map<ICollection<GetBranchDTO>>(branches);
        }
    }
}
