using Application.DTOs.EmployeesDTO;
using Application.Features.Employees.Handlers.Queries;
using Application.Features.Employees.Requests.Queries;
using Application.Features.Employees.Requests.Queries.Common;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
	public static class ApplicationServicesRegistoration
	{
		public static IServiceCollection ConfigurationApplicationServices(this IServiceCollection services)
		{
			var assembly = typeof(ApplicationServicesRegistoration).Assembly;

			services.AddMediatR(configuration =>
				configuration.RegisterServicesFromAssembly(assembly));

			services.AddValidatorsFromAssembly(assembly);

			services.AddAutoMapper(Assembly.GetExecutingAssembly());
			//services.AddMediatR(Assembly.GetExecutingAssembly());

			services.AddTransient<IRequestHandler<GetEmployeeByIdRequest, GetEmployeeDTO>, GetEmployeeByConditionRequestHandler>();
			services.AddTransient<IRequestHandler<GetEmployeeByEmailRequest, GetEmployeeDTO>, GetEmployeeByConditionRequestHandler>();
			services.AddTransient<IRequestHandler<GetEmployeeByEmployeeCodeRequest, GetEmployeeDTO>, GetEmployeeByConditionRequestHandler>();

			services.AddTransient<IRequestHandler<GetListEmployeeByGenderRequest, IEnumerable<GetEmployeeDTO>>, GetListEmployeeByConditionRequestHandler>();
			services.AddTransient<IRequestHandler<GetListEmployeeByBranchIdRequest, IEnumerable<GetEmployeeDTO>>, GetListEmployeeByConditionRequestHandler>();
			services.AddTransient<IRequestHandler<GetListEmployeeByNameRequest, IEnumerable<GetEmployeeDTO>>, GetListEmployeeByConditionRequestHandler>();
			services.AddTransient<IRequestHandler<GetListEmployeeByProvideServiceRequest, IEnumerable<GetEmployeeDTO>>, GetListEmployeeByConditionRequestHandler>();
			services.AddTransient<IRequestHandler<GetListEmployeeByRoleRequest, IEnumerable<GetEmployeeDTO>>, GetListEmployeeByConditionRequestHandler>();
			services.AddTransient<IRequestHandler<GetListEmployeeByYearOfBirthRequest, IEnumerable<GetEmployeeDTO>>, GetListEmployeeByConditionRequestHandler>();

			return services;
		}
	}
}
