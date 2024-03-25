using Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
	public class Offer : Entity
	{
		[Required(ErrorMessage = "{PropertyName} is required")]
		public decimal TotalPayment { get; set; }
		[Required(ErrorMessage = "{PropertyName} is required")]
		public DateTime StartDate { get; set; }
		[Required(ErrorMessage = "{PropertyName} is required")]
		public DateTime EndDate { get; set; }
		[Required(ErrorMessage = "{PropertyName} is required")]
		public string ProvideService { get; set; }

		//n-1 with Employee
		[Required(ErrorMessage = "{PropertyName} is required")]
		public Guid EmployeeId { get; set; }
		[ForeignKey("EmployeeId")]
		public virtual Employee? Employee { get; set; }
		//n-1 with Client
		[Required(ErrorMessage = "{PropertyName} is required")]
		public Guid ClientId { get; set; }
		[ForeignKey("ClientId")]
		public virtual Client? Client { get; set; }

		public Offer()
		{

		}
	}
}
