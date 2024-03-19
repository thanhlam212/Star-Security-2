using application.DTOs.Common.CreateDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.DTOs.Common.Validators
{
	public abstract class HumanCreateDTOValidator<T> : AbstractValidator<T> where T : HumanCreateDTO
	{
		public HumanCreateDTOValidator()
		{
			RuleFor(dto => dto.Name)
				.NotEmpty().WithMessage("{PropertyName} is required");

			RuleFor(dto => dto.Gender)
				.IsInEnum().WithMessage("{PropertyName} must be a valid gender");

			RuleFor(dto => dto.Email)
					.NotEmpty().WithMessage("{PropertyName} is required")
					.EmailAddress().WithMessage("Invalid email format");
		}
	}
}
