using Application.Contracts.Persistences;
using Application.Contracts.Persistences.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Repositories.Common;
using StarSecurityAPI.Data;
using Infrastrucutre.Repositories;

namespace Infrastructure
{
	public static class InfrastructureServicesRegistration
	{
		public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
		{
			var connection = configuration.GetConnectionString("MySQLConnection");
			services.AddDbContext<StarSecurityAPIContext>(options =>
				options.UseMySql(connection, ServerVersion.AutoDetect(connection)));

			/*services.AddDbContext<StarSecurityAPIContext>(
				options => options.UseMySql(configuration.GetConnectionString("MySQLConnection"),
				new MySqlServerVersion(new Version(8, 0, 2)),
				b => b.MigrationsAssembly(typeof(StarSecurityAPIContext).Assembly.FullName)),
				ServiceLifetime.Transient);*/
			/*services.AddDbContext<AppDbContext>(
				options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
				b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)),
				ServiceLifetime.Transient);*/

			services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

			services.AddLogging();
			services.AddScoped<IUnitOfWork, UnitOfWork>();

			services.AddScoped<IAccountRepository, AccountRepository>();
			services.AddScoped<IBranchRepository, BranchRepository>();
			services.AddScoped<IClientRepository, ClientRepository>();
			services.AddScoped<IEmployeeRepository, EmployeeRepository>();
			services.AddScoped<IOfferRepository, OfferRepository>();

			return services;
		}

	}
}
