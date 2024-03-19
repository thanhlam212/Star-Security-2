using domain.Common.Abstractions;
using domain.Common.Enums;
using domain.Common.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace domain.Entities
{
    public class Client(Name name,
		Gender gender,
		string? contractNumber,
		string? address,
		Email email,
		Guid? currentOfferId) : Human(name,
              gender,
              contractNumber,
              address,
              email)
    {
        // 1 - n with Offer
        //Missing, client can have multiple offers at a time 
        public virtual ICollection<Offer>? Offers { get; set; } //1-n relationship
		public Guid? CurrentOfferId { get; set; } = currentOfferId;
		public virtual Offer? CurrentOffer { get; set; } // hold the current offer
	}
}
