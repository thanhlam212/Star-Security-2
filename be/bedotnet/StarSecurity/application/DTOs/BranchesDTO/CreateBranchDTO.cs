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

namespace application.DTOs.BranchesDTO
{
    public class CreateBranchDTO : BasicCreateDTO
	{
		[Required]
		public Name Name { get; protected set; }
		[Required]
		public Region Region { get; protected set; }
		[Required]
		public string ContactDetail { get; protected set; }
		[Required]
		public Guid Manager { get;protected set; }
	}
}
