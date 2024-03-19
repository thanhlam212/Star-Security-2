using application.DTOs.EmployeesDTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Features.Employees.Requests.Queries.Common
{
    public class GetSingleEmployeeRequest : IRequest<GetEmployeeDTO>
    {
    }
}
