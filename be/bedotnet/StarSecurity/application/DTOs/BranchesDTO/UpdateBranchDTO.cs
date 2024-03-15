using application.DTOs.Common.UpdateDTO;
using domain.Common.Enums;
using domain.Common.ValueObjects;
using domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.DTOs.BranchesDTO
{
    public class UpdateBranchDTO : BasicUpdateDTO
	{
		public Name Name { get; protected set; }
		public Region Region { get; protected set; }
		public string ContactDetail { get; protected set; }
		public Guid Manager { get; protected set; }
	}
}
