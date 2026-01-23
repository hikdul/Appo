using Appo.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Appo.Identity.Helpers;
using Appo.Identity.Security;


namespace Appo.Identity
{
	//NOTA: con esto podemos separar hasta en otra locacion la base de datos del proyecto
    public class AppoIdentityDB:IdentityDbContext<User>
    {

		public AppoIdentityDB(DbContextOptions<AppoIdentityDB> opt): base(opt)
		{
		}

		protected AppoIdentityDB()
		{
		}

        protected override void OnModelCreating(ModelBuilder builder)
		{

            base.OnModelCreating(builder);

			builder.Entity<CompanyUserHasAllowed_pivot>()
				.HasKey(x => new {x.CompanyId, x.UserId, x.Alloweds});
		}

		//! desde esta tabla controlamos los permisos dinamicos
		public DbSet<CompanyUserHasAllowed_pivot> CompanyUserHasAllowedDinamyc { get; set; }

    }
}
