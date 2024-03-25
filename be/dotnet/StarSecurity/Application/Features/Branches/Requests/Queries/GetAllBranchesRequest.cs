using Application.DTOs.BranchesDTO;
using MediatR;

namespace Application.Features.Branches.Requests.Queries
{
	public class GetAllBranchesRequest : IRequest<ICollection<GetBranchDTO>>
    {

    }
}
