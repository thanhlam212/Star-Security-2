using application.DTOs.BranchesDTO;
using MediatR;

namespace application.Features.Branches.Requests.Queries
{
	public class GetAllBranchesRequest : IRequest<ICollection<GetBranchDTO>>
    {

    }
}
