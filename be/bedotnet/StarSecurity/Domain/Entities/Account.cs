using domain.Common.Abstractions;
using domain.Common.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Entities
{
    public class Account : Entity
    {
        [Required]
        public Email Email { get; protected set; }
        [Required]
        public string PasswordHash { get; protected set; }

        // 1 - 1 with Employee
        [Required]
        public Guid EmployeeId { get; protected set; }
        public virtual Employee Employee { get; protected set; }
    }
}
