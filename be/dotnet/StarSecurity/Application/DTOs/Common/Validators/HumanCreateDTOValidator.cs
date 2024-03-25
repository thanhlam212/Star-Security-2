using Application.DTOs.Common.CreateDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Common.Validators
{
	public abstract class HumanCreateDTOValidator<T> : AbstractValidator<T> where T : HumanCreateDTO
	{
		public HumanCreateDTOValidator()
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
