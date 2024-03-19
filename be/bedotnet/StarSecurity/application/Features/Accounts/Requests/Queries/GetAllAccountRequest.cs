using application.DTOs.AccountsDTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Features.Accounts.Requests.Queries
{
    public class GetAllAccountRequest : IRequest<ICollection<GetAccountDTO>>
    {

    }
}
