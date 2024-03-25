using Application.Contracts.Persistences;
using Application.DTOs.AccountsDTO.Validators;
using Application.DTOs.BranchesDTO.Validator;
using Application.Features.Accounts.Requests.Commands;
using Application.Features.Branches.Requests.Commands;
using AutoMapper;
using Domain.Common.Exceptions;
using Domain.Entities;
using MediatR;

namespace Application.Features.Accounts.Handlers.Commands
{
	public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand, Unit>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly UpdateAccountDTOValidator _validator;
		private readonly IMapper _mapper;

		public UpdateAccountCommandHandler(
			IUnitOfWork unitOfWork,
			UpdateAccountDTOValidator validator,
			IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_validator = validator;
			_mapper = mapper;
		}
		public async Task<Unit> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
		{
			var validationResult = await _validator.ValidateAsync(request.UpdateAccountDTO);
			if (!validationResult.IsValid)
			{
				throw new ValidationException(validationResult);
			}
			var account = await _unitOfWork.AccountRepository.GetByIdAsync(request.UpdateAccountDTO.Id)
				?? throw new NotFoundException(nameof(Account), request.UpdateAccountDTO.Id);

			_mapper.Map(request.UpdateAccountDTO, account);

			var isUpdated = await _unitOfWork.AccountRepository.UpdateAsync(account);
			if (!isUpdated)
			{
				throw new Exception("Account updated failed!");
			}
			return Unit.Value;
		}
	}
}
