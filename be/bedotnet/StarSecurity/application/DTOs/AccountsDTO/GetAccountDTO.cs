using application.DTOs.Common.GetDTO;
using domain.Common.ValueObjects;
using domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.DTOs.AccountsDTO
{
    public class GetAccountDTO : BasicGetDTO
    {
        public Email Email { get; protected set; }
        public string PasswordHash { get; protected set; }
        public Employee Employee { get; protected set; }
    }
}
