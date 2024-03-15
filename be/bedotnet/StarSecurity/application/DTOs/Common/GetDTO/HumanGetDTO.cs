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

        public Name Name { get; protected set; }
        public Gender Gender { get; protected set; }
        public string? Address { get; protected set; }
        public string? ContactNumber { get; protected set; }
        public Email EmailAdress { get; protected set; }
    }
}
