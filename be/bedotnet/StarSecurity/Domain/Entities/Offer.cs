using domain.Common.Abstractions;
using domain.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Entities
{
    public class Offer : Entity
    {
        [Required]
        public decimal TotalPayment { get; protected set; }
        [Required]
        public DateTime StartDate { get; protected set; }
        [Required]
        public DateTime EndDate { get; protected set; }
        [Required]
        public ProvideService ProvideService { get; protected set; }

        //n-1 with Employee
        [Required]
        public Guid EmployeeId { get; protected set; }
        public virtual Employee Employee { get; protected set; }
        //n-1 with Client
        [Required]
        public Guid ClientId { get; protected set; }
        public virtual Client Client { get; protected set; }
    }
}
