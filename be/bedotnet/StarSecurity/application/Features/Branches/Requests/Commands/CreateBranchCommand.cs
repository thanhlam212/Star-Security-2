using application.DTOs.BranchesDTO;
using MediatR;

namespace application.Features.Branches.Requests.Commands
{
    public class CreateBranchCommand : IRequest<Guid>
    {
        public CreateBranchDTO CreateBranchDTO { get; set; }
    }
}
