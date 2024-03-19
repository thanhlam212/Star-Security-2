using application.DTOs.Common.GetDTO;
using domain.Common.ValueObjects;
using domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.DTOs.ClientsDTO
{
    public class GetClientDTO : HumanGetDTO
    {
        public Offer? CurrentOffer {  get; set; }
    }
}
