using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.DTOs.AccountsDTO.Validators
{
	public class CreateAccountDTOValidator : AbstractValidator<CreateAccountDTO>
	{
		public CreateAccountDTOValidator()
		{
			RuleFor(account => account.Email)
				.NotEmpty().WithMessage("{PropertyName} is required")
				.EmailAddress().WithMessage("Invalid email format");
			RuleFor(account => account.PasswordHash)
				.NotEmpty().WithMessage("{PropertyName} is required")
				.MinimumLength(6).WithMessage("{PropertyName} must be at least 6 characters");
			RuleFor(account => account.EmployeeId)
				.NotEmpty().WithMessage("{PropertyName} is required")
				.NotEqual(Guid.Empty).WithMessage("{PropertyName} cannot be empty");
		}
	}
}
