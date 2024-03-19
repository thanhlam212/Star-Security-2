using application.DTOs.Common.CreateDTO;
using domain.Common.Enums;
using domain.Common.ValueObjects;
using domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.DTOs.OffersDTO
{
	public class CreateOfferDTO : BasicCreateDTO
	{
		[Required(ErrorMessage = "{PropertyName} is required")]
		public decimal TotalPayment { get; protected set; }
		[Required(ErrorMessage = "{PropertyName} is required")]
		public DateTime StartDate { get; protected set; }
		[Required(ErrorMessage = "{PropertyName} is required")]
		public DateTime EndDate { get; protected set; }
		[Required(ErrorMessage = "{PropertyName} is required")]
		public ProvideService ProvideService { get; protected set; }
		[Required(ErrorMessage = "{PropertyName} is required")]
		public Guid ClientId { get; protected set; }
		[Required(ErrorMessage = "{PropertyName} is required")]
		public Guid EmployeeId { get; protected set; }
	}
}
