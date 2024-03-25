using FluentValidation;

namespace Application.DTOs.BranchesDTO.Validator
{
	public class UpdateBranchDTOValidator : AbstractValidator<UpdateBranchDTO>
	{
		public UpdateBranchDTOValidator()
		{
			RuleFor(dto => dto.Name)
				.NotEmpty().WithMessage("{PropertyName} is required");

			RuleFor(dto => dto.Region)
				.NotEmpty().WithMessage("{PropertyName} is required");

			RuleFor(dto => dto.ContactDetail)
				.NotEmpty().WithMessage("{PropertyName} is required");
		}
	}
}
