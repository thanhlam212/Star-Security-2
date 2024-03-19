using application.DTOs.BranchesDTO.Validator;
using application.Features.Branches.Requests.Commands;
using application.Persistences.Contracts;
using AutoMapper;
using MediatR;

namespace application.Features.Branches.Handlers.Commands
{
	public class UpdateBranchCommandHandler : IRequestHandler<UpdateBranchCommand, Unit>
	{
		private readonly IBranchRepository _branchRepository;
		private readonly UpdateBranchDTOValidator _validator;
		private readonly IMapper _mapper;

		public UpdateBranchCommandHandler(
			IBranchRepository branchRepository,
			UpdateBranchDTOValidator validator,
			IMapper mapper)
        {
			_branchRepository = branchRepository;
			_validator = validator;
			_mapper = mapper;
		}
        public async Task<Unit> Handle(UpdateBranchCommand request, CancellationToken cancellationToken)
		{
			var validationResult = await _validator.ValidateAsync(request.UpdateBranchDTO);
			if (!validationResult.IsValid)
			{
				throw new Exception();
			}
			var branch = await _branchRepository.GetByIdAsync(request.UpdateBranchDTO.Id) ?? throw new Exception("No branch found!!");
			_mapper.Map(request.UpdateBranchDTO, branch);

			var isUpdated = await _branchRepository.UpdateAsync(branch); 
			if (!isUpdated) 
			{
				throw new Exception("No Branch updated!!");
			}
			return Unit.Value;
		}
	}
}
