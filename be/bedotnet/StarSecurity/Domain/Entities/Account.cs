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
		[Required(ErrorMessage = "{PropertyName} is required")]
		[EmailAddress]
        public Email Email { get; set; }
		[Required(ErrorMessage = "{PropertyName} is required")]
		public string PasswordHash { get; set; }

		// 1 - 1 with Employee
		[Required(ErrorMessage = "{PropertyName} is required")]
		public Guid EmployeeId { get; set; }
        public virtual Employee? Employee { get; set; }
		public Account(Email email, string passwordHash, Guid employeeId) : base()
		{
			Email = email ?? throw new ArgumentNullException(nameof(email));
			PasswordHash = passwordHash ?? throw new ArgumentNullException(nameof(passwordHash));
			EmployeeId = employeeId;
		}
	}
}
