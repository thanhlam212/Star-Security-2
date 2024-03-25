using Application.DTOs.Common.GetDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.AccountsDTO
{
	public class GetAccountDTO : BasicGetDTO
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public Guid EmployeeId { get; set; }
    }
}
