using Microsoft.EntityFrameworkCore;
using Appo.Core.Entities;

namespace Appo.Persistence
{
	public class AppoDBContext: DbContext
	{
		public AppoDBContext(DbContextOptions<AppoDBContext> options): base(options)
		{

		}

		protected AppoDBContext()
		{

		}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppoDBContext).Assembly);
        }

		public DbSet<Company> Companys { get; set; }
	}
}
