using application.Contracts.Persistences;
using application.Contracts.Persistences.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;
using Persistence.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class PersistenceServicesRegistration
	{
		public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<StarSecurityDbContext>(options => 
				options.UseSqlServer(
					configuration.GetConnectionString("StarSecurityConnectionString")));

			services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
			services.AddScoped<IAccountRepository, AccountRepository>();
			services.AddScoped<IBranchRepository, BranchRepository>();
			services.AddScoped<IClientRepository, ClientRepository>();
			services.AddScoped<IEmployeeRepository, EmployeeRepository>();
			services.AddScoped<IOfferRepository, OfferRepository>();

			return services;
		}

	}
}
