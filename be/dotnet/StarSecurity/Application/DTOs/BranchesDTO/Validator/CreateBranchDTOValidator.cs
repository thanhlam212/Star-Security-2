using Application.DTOs.BranchesDTO;
using FluentValidation;

namespace Application.DTOs.BranchesDTO.Validator
{
	public class CreateBranchDTOValidator : AbstractValidator<CreateBranchDTO>
    {
        public CreateBranchDTOValidator()
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
