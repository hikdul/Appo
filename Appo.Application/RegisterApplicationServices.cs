using Appo.Aplication.Features.Companys.Commands;
using Appo.Aplication.Features.Companys.Querys;
//using Appo.Aplication.Features.Utilities;
using Appo.Aplication.Utilities.Mediator;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scrutor;

namespace Appo.Application
{

	public static class RegisterApplicationServices
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services)
		{

			services.AddTransient<IMediator, MediatorSimple>();

			services.Scan(scan => scan.FromAssembliesOf(typeof(RegisterApplicationServices))
					.AddClasses(c => c.AssignableTo(typeof(IRequestHandler<>)))
					.AsImplementedInterfaces()
					.WithScopedLifetime()
					.AddClasses(c => c.AssignableTo(typeof(IRequestHandler<,>)))
					.AsImplementedInterfaces()
					.WithScopedLifetime());


			return services;
		}
	}
}
