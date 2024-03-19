using MediatR;

namespace application.Features.Branches.Requests.Commands
{
    public class DeleteBranchCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
