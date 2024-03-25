using Application.DTOs.Common.UpdateDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.OffersDTO
{
	public class UpdateOfferDTO : BasicUpdateDTO
	{
		[Required(ErrorMessage = "{PropertyName} is required")]
		public decimal TotalPayment { get; protected set; }
		[Required(ErrorMessage = "{PropertyName} is required")]
		public DateTime StartDate { get; protected set; }
		[Required(ErrorMessage = "{PropertyName} is required")]
		public DateTime EndDate { get; protected set; }
		[Required(ErrorMessage = "{PropertyName} is required")]
		public string ProvideService { get; protected set; }
		[Required(ErrorMessage = "{PropertyName} is required")]
		public Guid ClientId { get; protected set; }
		[Required(ErrorMessage = "{PropertyName} is required")]
		public Guid EmployeeId { get; protected set; }
	}
}
