using Domain.Entities.Common;

namespace Domain.Entities
{
	public class Client : Human
	{
		public Client(
			string name, 
			string gender, 
			DateTime dateOfBirth, 
			string? address, 
			string? contactNumber, 
			string email,
			Guid? currentOfferId) 
			: base(name, 
				  gender, 
				  dateOfBirth, 
				  address, 
				  contactNumber, 
				  email)
		{
			CurrentOfferId = currentOfferId;
		}

		//Missing, client can have multiple offers at a time 
		public Guid? CurrentOfferId { get; set; }
		public virtual ICollection<Offer>? Offers { get; set; }

 
    }
}
