using application.DTOs.Common.UpdateDTO;
using domain.Common.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.DTOs.ClientsDTO
{
	public class UpdateClientDTO : HumanUpdateDTO
	{
		public Guid? CurrentOffer { get; protected set; }
	}
}
