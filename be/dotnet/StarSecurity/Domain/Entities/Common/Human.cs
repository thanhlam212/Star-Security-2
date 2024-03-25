using Domain.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Common
{
	public abstract class Human : Entity
	{
		private Human human;

		[Required(ErrorMessage = "{PropertyName} is required")]
		public string Name { get; set; }
		[Required(ErrorMessage = "{PropertyName} is required")]
		public string Gender { get; set; }
		[Required(ErrorMessage = "{PropertyName} is required")]
		public DateTime DateOfBirth { get; set; }
		public string? Address { get; set; }
		[Required(ErrorMessage = "{PropertyName} is required")]
		[Phone]
		public string? ContactNumber { get; set; }
		[Required(ErrorMessage = "{PropertyName} is required")]
		[EmailAddress]
		public string Email { get; set; }
        public Human(
			string name,
			string gender,
			DateTime dateOfBirth,
			string? address,
			string? contactNumber,
			string email) : base()
        {
            Name = name;
			Gender = gender;
			DateOfBirth = dateOfBirth;
			Address = address;
			ContactNumber = contactNumber;
			Email = email;
        }

		protected Human(Human human)
		{
			this.human = human;
		}
	}
}
