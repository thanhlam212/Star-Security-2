using Application.DTOs.Common.GetDTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.ClientsDTO
{
    public class GetClientDTO : HumanGetDTO
    {
        public Offer? CurrentOffer {  get; set; }
    }
}
