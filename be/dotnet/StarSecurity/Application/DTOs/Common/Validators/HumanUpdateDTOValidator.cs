using Application.DTOs.Common.UpdateDTO;
using FluentValidation;

namespace Application.DTOs.Common.Validators
{
	public abstract class HumanUpdateDTOValidator<T> : AbstractValidator<T> where T : HumanUpdateDTO
	{
		public HumanUpdateDTOValidator()
		{
			RuleFor(dto => dto.Name)
				.NotEmpty().WithMessage("{PropertyName} is required");

			RuleFor(dto => dto.Gender)
				.NotEmpty().WithMessage("{PropertyName} is required");

			RuleFor(dto => dto.DateOfBirth)
				.NotEmpty().WithMessage("{PropertyName} is required");

			RuleFor(dto => dto.Email)
				.NotEmpty().WithMessage("{PropertyName} is required")
				.EmailAddress().WithMessage("Invalid email format");
		}
	}
}
