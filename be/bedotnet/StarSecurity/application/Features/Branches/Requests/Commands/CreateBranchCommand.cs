using application.DTOs.BranchesDTO;
using domain.Common.Responses;
using MediatR;

namespace application.Features.Branches.Requests.Commands
{
    public class CreateBranchCommand : IRequest<BaseCommandRespond>
    {
        public CreateBranchDTO CreateBranchDTO { get; set; }
    }
}
