using Microsoft.EntityFrameworkCore;
using Appo.Core.Entities;
using Appo.Application.Contracts.Identity;
using Appo.Core.Commons;
using System.Linq.Expressions;
using System.Reflection;
using Appo.Application.Exceptions;

namespace Appo.Persistence
{
	public class AppoDBContext: DbContext
	{
		private readonly IUsersServices? userServices;
		public Guid tenantId;

		public AppoDBContext(DbContextOptions<AppoDBContext> options, IUsersServices _userServices, IIdTenantService _idTenant): base(options)
		{
			this.userServices = _userServices;
			this.tenantId = _idTenant.GetTenantId()!;
		}

		protected AppoDBContext()
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// ===========================================>
			//?: Generamos el metodo de filtrado general.
			foreach (var Entity in modelBuilder.Model.GetEntityTypes())
			{
				//Note: el codigo entregado por Felipe Gavilan se modifico un poco para que trabajara con mayor control de errores
				var type = Entity.ClrType;

				if(typeof(ITenantEnt).IsAssignableFrom(type))
 				//TODO: Generar el filtro o salto de validacion para clases que no pertenecen al tenant
				{

					var method = typeof(AppoDBContext).GetMethod(nameof(BuildGlobarFilterTenant), BindingFlags.NonPublic | BindingFlags.Static); //?.MakeGenericMethod(type);

					if(method is null)
						throw new AppoTenantException("Error to obtain a method exp"); //TODO: Crear excepcion para este elemento

					var filter = method?.Invoke(null, new object[] {this})!;

					if(filter is not LambdaExpression lambda)
						throw new AppoTenantException("Error to apply filter"); //TODO: Crear excepcion para este elemento

					Entity.SetQueryFilter(lambda);

					var tprop = Entity.FindProperty(nameof(ITenantEnt.TenantId));

					if(tprop is not null)
					{
						Entity.SetQueryFilter((LambdaExpression)filter!);
						Entity.AddIndex(tprop);

					}
				}
			}
			// END
			// ===========================================>

			modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppoDBContext).Assembly);
		}

		// Note: En esta clase lo que aplicamos es que cada ver que se generen cambios en el sistema... podremos notal quien genero el cambio...
		public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{

			if (userServices is not null)
			{
				foreach (var entry in ChangeTracker.Entries<AuditEnt>())
				{
					switch (entry.State)
					{
						case EntityState.Added:
							entry.Entity.CreatedDate = DateTime.UtcNow;
							entry.Entity.CreatedBy = userServices.GetUserId();
							// => aca se asigna siempre el TenantId; por tanto yo no hago esa asignacion nunca
							if(entry.Entity is ITenantEnt)
							{
								(entry.Entity as ITenantEnt)!.TenantId = tenantId;
							}
							break;

						case EntityState.Modified:
							entry.Entity.UpdateDate = DateTime.UtcNow;
							entry.Entity.UpdateBy = userServices.GetUserId();
							break;
					}
				}
			}

			return base.SaveChangesAsync(cancellationToken);
		}

		private static LambdaExpression BuildGlobarFilterTenant<TEnt>(AppoDBContext _context) where TEnt : class, ITenantEnt
		{
			Expression<Func<TEnt, bool>> filter = x => x.TenantId == _context.tenantId;
			return filter;
		}

		public DbSet<Company> Companys { get; set; }
		public DbSet<WorkCenter> WorkCenters { get; set; }
		public DbSet<Person> Persons { get; set; }
		public DbSet<Partner> Partners { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Appoiment> Appoiments {get; set; }
	}
}

