using Microsoft.EntityFrameworkCore;
using Appo.Core.Entities;
using Appo.Application.Contracts.Identity;
using Appo.Core.Commons;

namespace Appo.Persistence
{
	public class AppoDBContext: DbContext
	{
		private readonly IUsersServices? userServices;
		public AppoDBContext(DbContextOptions<AppoDBContext> options, IUsersServices _userServices): base(options)
		{
			this.userServices = _userServices;
		}

		protected AppoDBContext()
		{

		}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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

		public DbSet<Company> Companys { get; set; }
		public DbSet<WorkCenter> WorkCenters { get; set; }
		public DbSet<Person> Persons { get; set; }
		public DbSet<Partner> Partners { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Appoiment> Appoiments {get; set; }
	}
}

