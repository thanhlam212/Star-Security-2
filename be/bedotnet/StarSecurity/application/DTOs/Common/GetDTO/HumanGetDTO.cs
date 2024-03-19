using domain.Common.Enums;
using domain.Common.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.DTOs.Common.GetDTO
{
    public abstract class HumanGetDTO : BasicGetDTO
    {

        public Name Name { get; set; }
        public Gender Gender { get; set; }
        public string? Address { get; set; }
        public string? ContactNumber { get; set; }
        public Email Email { get; set; }
    }
}
