using Appo.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Appo.Application.Contracts.Identity;
using Appo.Identity.Services;
using Appo.Identity.Security;
using  Microsoft.AspNetCore.Authorization ;

namespace Appo.Identity
{
    public static class RegisterIdentityServices
    {
		public static IServiceCollection AddIdentityServices(this IServiceCollection services, string DatabaseName)
		{
			services.AddAuthentication(IdentityConstants.BearerScheme).AddBearerToken(IdentityConstants.BearerScheme);

			services.AddAuthorizationBuilder();

			services.AddDbContext<AppoIdentityDB>(opt => opt.UseSqlServer(DatabaseName));

			services.AddIdentityCore<User>()
				.AddEntityFrameworkStores<AppoIdentityDB>()
				.AddApiEndpoints();

			services.AddTransient<IUsersServices, UsersServices>();
			services.AddTransient<ITenantServices, TenantServices>();
			services.AddTransient<IIdTenantService, IdTenanService>();
			services.AddSingleton<IAuthorizationPolicyProvider,HasAllowPolicyProvider>();
			services.AddScoped<IAuthorizationHandler,HasAllowHandler>();
			services.AddHttpContextAccessor();

			return services;

		}
    }
}
