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
    public class Client : Human
    {
        // 1 - n with Offer
        public virtual ICollection<Offer> Offers { get; set; } //1-n relationship
        public Guid? OfferId { get; protected set; }
        public virtual Offer? CurrentOffer { get; protected set; } // hold the current offer

        // Constructor của Client
        public Client(Name name,
            Gender gender,
            string contractNumber,
            string address,
            Email email,
            Offer currentOffer)
            : base(name,
                  gender,
                  contractNumber,
                  address,
                  email)
        {
            CurrentOffer = currentOffer;
        }
    }
}
