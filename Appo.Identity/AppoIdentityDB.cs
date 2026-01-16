using Appo.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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

    }
}
