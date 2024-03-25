using Application.DTOs.Common.GetDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.BranchesDTO
{
    public class GetBranchDTO : BasicGetDTO
    {
		public string Name { get; set; }
		public string Region { get; set; }
		public string ContactDetail { get; set; }
	}
}
