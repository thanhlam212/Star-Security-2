using application.DTOs.BranchesDTO;
using MediatR;

namespace application.Features.Branches.Requests.Commands
{
    public class UpdateBranchCommand : IRequest<Unit>
    {
        public UpdateBranchDTO UpdateBranchDTO { get; set; }
    }
}
