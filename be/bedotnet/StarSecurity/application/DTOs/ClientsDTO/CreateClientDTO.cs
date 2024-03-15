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

namespace application.DTOs.ClientsDTO
{
	public class CreateClientDTO : HumanCreateDTO
	{
		public Guid? CurrentOffer { get; protected set; }
	}
}
