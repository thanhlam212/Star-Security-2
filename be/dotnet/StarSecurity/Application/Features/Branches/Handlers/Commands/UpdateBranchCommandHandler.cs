using Application.Contracts.Persistences;
using Application.DTOs.BranchesDTO.Validator;
using Application.Features.Branches.Requests.Commands;
using AutoMapper;
using Domain.Common.Exceptions;
using Domain.Entities;
using MediatR;

namespace Application.Features.Branches.Handlers.Commands
{
    public class UpdateBranchCommandHandler : IRequestHandler<UpdateBranchCommand, Unit>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly UpdateBranchDTOValidator _validator;
		private readonly IMapper _mapper;

		public UpdateBranchCommandHandler(
			IUnitOfWork unitOfWork,
			UpdateBranchDTOValidator validator,
			IMapper mapper)
        {
			_unitOfWork = unitOfWork;
			_validator = validator;
			_mapper = mapper;
		}
        public async Task<Unit> Handle(UpdateBranchCommand request, CancellationToken cancellationToken)
		{
			var validationResult = await _validator.ValidateAsync(request.UpdateBranchDTO);
			if (!validationResult.IsValid)
			{
				throw new ValidationException(validationResult);
			}
			var branch = await _unitOfWork.BranchRepository.GetByIdAsync(request.UpdateBranchDTO.Id) 
				?? throw new NotFoundException(nameof(Branch), request.UpdateBranchDTO.Id);
			_mapper.Map(request.UpdateBranchDTO, branch);

			var isUpdated = await _unitOfWork.BranchRepository.UpdateAsync(branch); 
			if (!isUpdated) 
			{
				throw new Exception("No Branch updated!!");
			}
			return Unit.Value;
		}
	}
}
