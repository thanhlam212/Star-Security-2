using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Common.CreateDTO
{
    public abstract class HumanCreateDTO : BasicCreateDTO
	{
		[Required(ErrorMessage = "{PropertyName} is required")]
		public string Name { get; set; }
		[Required(ErrorMessage = "{PropertyName} is required")]
		public string Gender { get; set; }
		[Required(ErrorMessage = "{PropertyName} is required")]
		public DateTime DateOfBirth { get; set; }
		public string? Address { get; set; }
		public string? ContactNumber { get; set; }
		[Required(ErrorMessage = "{PropertyName} is required")]
		[EmailAddress]
		public string Email { get; set; }
	}
}
