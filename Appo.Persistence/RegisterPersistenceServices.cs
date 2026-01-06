using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using CleanTeeth.Persistence.Repositories;
using Appo.Aplication.Contracts.Repositories;
using Appo.Aplication.Contracts.Persistence;
using Appo.Persistence.UnitsOfWorks;

namespace Appo.Persistence
{
	public static class RegisterPersistenceServices
	{
		public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
		{


			services.AddDbContext<AppoDBContext>(options => options.UseSqlServer("name=AppoDB"));

			services.AddScoped<IRepositoryCompany ,CompanyRepository>();

			services.AddScoped<IUnitOfWork, UnitOfWorkEFCore>();

			return services;
		}
	}
}
