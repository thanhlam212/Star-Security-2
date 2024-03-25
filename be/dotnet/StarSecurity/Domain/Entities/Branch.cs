using Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics;

namespace Domain.Entities
{
	public class Branch : Entity
	{
		[Required(ErrorMessage = "{PropertyName} is required")]
		public string Name { get; set; }
		[Required(ErrorMessage = "{PropertyName} is required")]
		public string Region { get; set; }
		[Required(ErrorMessage = "{PropertyName} is required")]
		public string ContactDetail { get; set; }

		// 1 - n with Employee
		public virtual ICollection<Employee> Employee { get; set; }

        public Branch(string name, string region, string contactDetail) : base()
        {
            Name = name;
			Region = region;
			ContactDetail = contactDetail;
        }
    }
}
