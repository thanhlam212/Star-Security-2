using System.ComponentModel.DataAnnotations;


namespace Application.DTOs.Common.DeleteDTO
{
	public abstract class BasicDeleteDTO
	{
		[Required(ErrorMessage = "{PropertyName} is required")]
		public Guid Id { get; set; }
	}
}
