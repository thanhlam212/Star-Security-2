using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.DTOs.OffersDTO.Validators
{
	public class CreateOfferValidator : AbstractValidator<CreateOfferDTO>
	{
		public CreateOfferValidator()
		{
			RuleFor(offer => offer.StartDate)
				.NotEmpty().WithMessage("{PropertyName} is required")
				.Must((dto, startdate) => startdate < dto.EndDate)
				.WithMessage("Start date must be before end date");
		}
	}
}
