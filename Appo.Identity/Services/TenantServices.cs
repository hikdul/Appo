
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Appo.Application.Contracts.Identity;
using Appo.Identity.Models;
using Appo.Aplication.Exceptions;

using System.Security.Claims;

namespace Appo.Identity.Services
{
    public class TenantServices: ITenantServices
    {

        private readonly UserManager<User> userManager;
		private readonly AppoIdentityDB context;

		public TenantServices(UserManager<User> _useMannagement, AppoIdentityDB _context )
		{
			this.userManager = _useMannagement;
			this.context = _context;
		}

		public async Task ChangeTenantUser(Guid CompanyId, string userid)
		{
			var user =  await userManager.FindByIdAsync(userid);

			if(user is null)
			{
				throw new NotFoundException();
			}

			var claimExists = await context.UserClaims.FirstOrDefaultAsync(x => x.ClaimType == Services.Constants.CLAIMTENANTID  && x.UserId == userid);

			if (claimExists is not null)
			{
				context.Remove(claimExists);
			}

            var NewClaim = new Claim(Services.Constants.CLAIMTENANTID, CompanyId.ToString());

            await userManager.AddClaimAsync(user, NewClaim);

		}

    }
}
