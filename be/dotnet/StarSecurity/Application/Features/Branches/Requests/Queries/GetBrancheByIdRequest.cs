using Application.DTOs.BranchesDTO;
using MediatR;

namespace Application.Features.Branches.Requests.Queries
{
	public class GetBranchByIdRequest : IRequest<GetBranchDTO>
	{
		public Guid Id { get; set; }
	}
}
