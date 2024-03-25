using Application.DTOs.EmployeesDTO;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Employees.Requests.Queries.Common
{
    public class GetAllEmployeeRequest : IRequest<IEnumerable<GetEmployeeDTO>>
    {
    }
}
