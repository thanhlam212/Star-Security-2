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

namespace application.DTOs.BranchesDTO
{
    public class GetBranchDTO : BasicGetDTO
    {
		public Name Name { get; set; }
		public Region Region { get; set; }
		public string ContactDetail { get; set; }
		public Employee Manager { get; set; }
	}
}
