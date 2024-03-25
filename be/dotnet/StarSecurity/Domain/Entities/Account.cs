using Domain.Common.Enums;
using Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Domain.Entities
{
	public class Account : Entity
	{
		[Required(ErrorMessage = "{PropertyName} is required")]
		[EmailAddress]
		public string Email { get; set; }
		[Required(ErrorMessage = "{PropertyName} is required")]
		public string PasswordHash { get; set; }
		[Required(ErrorMessage = "{PropertyName} is required")]
		// 1-1 with employee
		public Guid EmployeeId { get; set; }
		[ForeignKey("EmployeeId")]
		public virtual Employee? Employee { get; set; }

		public Account(string email, string passwordHash, Guid employeeId) : base()
		{
			Email = email;
			PasswordHash = passwordHash;
			EmployeeId = employeeId;
		}
	}
}
