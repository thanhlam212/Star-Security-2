using application.DTOs.Common.GetDTO;
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
	public class GetOfferDTO : BasicGetDTO
	{
		public decimal TotalPayment { get; protected set; }
		public DateTime StartDate { get; protected set; }
		public DateTime EndDate { get; protected set; }
		public ProvideService ProvideService { get; protected set; }
		public Client Client { get; protected set; }
		public Employee Employee { get; protected set; }
	}
}
