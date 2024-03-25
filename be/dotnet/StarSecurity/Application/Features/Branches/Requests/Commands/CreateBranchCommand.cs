using Application.DTOs.BranchesDTO;
using MediatR;

namespace Application.Features.Branches.Requests.Commands
{
    public class CreateBranchCommand : IRequest<Guid>
    {
        public CreateBranchDTO CreateBranchDTO { get; set; }
    }
}
