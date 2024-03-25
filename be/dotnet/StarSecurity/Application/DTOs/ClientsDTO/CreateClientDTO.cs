using Application.DTOs.Common.CreateDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.ClientsDTO
{
	public class CreateClientDTO : HumanCreateDTO
	{
		public Guid? CurrentOfferId { get; set; }
	}
}
