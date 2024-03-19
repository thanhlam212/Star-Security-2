using FluentValidation;

namespace application.DTOs.OffersDTO.Validators
{
	public class UpdateOfferValidator : AbstractValidator<UpdateOfferDTO>
	{
		public UpdateOfferValidator()
		{
			RuleFor(offer => offer.StartDate)
				.NotEmpty().WithMessage("{PropertyName} is required")
				.Must((dto, startdate) => startdate < dto.EndDate)
				.WithMessage("Start date must be before end date");
		}
	}
}
