using application.DTOs.Common.UpdateDTO;
using FluentValidation;

namespace application.DTOs.Common.Validators
{
	public abstract class HumanUpdateDTOValidator<T> : AbstractValidator<T> where T : HumanUpdateDTO
	{
		public HumanUpdateDTOValidator()
		{
			RuleFor(dto => dto.Name)
				.NotEmpty().WithMessage("{PropertyName} is required");

			RuleFor(dto => dto.Gender)
				.IsInEnum().WithMessage("{PropertyName} must be a valid gender");

			RuleFor(dto => dto.DateOfBirth)
				.IsInEnum().WithMessage("{PropertyName} is required");

			RuleFor(dto => dto.Email)
				.NotEmpty().WithMessage("{PropertyName} is required")
				.EmailAddress().WithMessage("Invalid email format");
		}
	}
}
