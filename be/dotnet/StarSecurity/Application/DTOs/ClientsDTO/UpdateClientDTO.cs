using Application.DTOs.Common.UpdateDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.ClientsDTO
{
	public class UpdateClientDTO : HumanUpdateDTO
	{
		public Guid? CurrentOffer { get; set; }
	}
}
