using domain.Common.Abstractions;
using domain.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Entities
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
		public ProvideService ProvideService { get; set; }

		//n-1 with Employee
		[Required(ErrorMessage = "{PropertyName} is required")]
		public Guid EmployeeId { get; set; }
        public virtual Employee? Employee { get; set; }
		//n-1 with Client
		[Required(ErrorMessage = "{PropertyName} is required")]
		public Guid ClientId { get; set; }
        public virtual Client? Client { get; set; }

		public Offer(decimal totalPayment, 
            DateTime startDate, 
            DateTime endDate, 
            ProvideService provideService, 
            Guid employeeId, 
            Guid clientId) 
            : base()
        {
			TotalPayment = totalPayment;
			StartDate = startDate;
			EndDate = endDate;
			ProvideService = provideService;
			EmployeeId = employeeId;
			ClientId = clientId;
		}
	}
}
