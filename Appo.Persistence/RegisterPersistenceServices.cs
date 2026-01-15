using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using CleanTeeth.Persistence.Repositories;
using Appo.Aplication.Contracts.Repositories;
using Appo.Aplication.Contracts.Persistence;
using Appo.Persistence.UnitsOfWorks;
using Appo.Application.Contracts.Repositories;
using Appo.Persistence.Repositories;

namespace Appo.Persistence
{
	public static class RegisterPersistenceServices
	{
		public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
		{

			services.AddDbContext<AppoDBContext>(options => options.UseSqlServer("name=AppoDB"));

			services.AddScoped<IRepositoryCompany ,CompanyRepository>();
			services.AddScoped<IRepositoryWorkCenter ,WorkCenterRepository>();
			services.AddScoped<IRepositoryPerson , PersonRepository>();
			services.AddScoped<IRepositoryCustomer, CustomerRepository>();
			services.AddScoped<IRepositoryPartner, PartnerRepository>();

			services.AddScoped<IUnitOfWork, UnitOfWorkEFCore>();

			return services;
		}
	}
}
