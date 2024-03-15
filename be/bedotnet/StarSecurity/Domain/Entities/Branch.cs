using domain.Common.Abstractions;
using domain.Common.Enums;
using domain.Common.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Entities
{
    public class Branch : Entity
    {
        [Required]
        public Name Name { get; set; }
        [Required]
        public Region Region { get; set; }
        [Required]
        public string ContactDetail { get; set; }

        // 1 - n with Employee
        public virtual ICollection<Employee> Employee { get; set; }

        // Manager
        public Guid? ManagerId { get; set; }
        public virtual Employee Manager { get; set; }
    }
}
