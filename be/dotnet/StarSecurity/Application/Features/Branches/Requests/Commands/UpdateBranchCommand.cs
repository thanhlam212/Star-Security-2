using Application.DTOs.BranchesDTO;
using MediatR;

namespace Application.Features.Branches.Requests.Commands
{
    public class UpdateBranchCommand : IRequest<Unit>
    {
        public UpdateBranchDTO UpdateBranchDTO { get; set; }
    }
}
