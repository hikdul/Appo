
using Appo.Application.Contracts.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Appo.Identity.Security
{
    public class HasAllowHandler: AuthorizationHandler<HasAllowRequirement>
    {
		private readonly IIdTenantService tenant;
		private readonly IUsersServices user;
		private readonly AppoIdentityDB dbCotext; //?? si sera esta o tendre que ir hasta el otro punto; pero lo ideal seria manipularlo desde este servicio...

		public HasAllowHandler(IIdTenantService _tenant, IUsersServices _user, AppoIdentityDB _db)
		{
		    this.tenant = _tenant;
			this.user = _user;
			this.dbCotext = _db;
		}

		protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, HasAllowRequirement requirement)
		{
			var allow = requirement.allow;
			var userid = user.GetUserId();
			var companyId = tenant.GetTenantId();

			var hasAllow = await dbCotext.CompanyUserHasAllowedDinamyc
				.AnyAsync(x => x.UserId == userid
					&& x.CompanyId == companyId
					&& x.Alloweds == allow);

			if(hasAllow)
			{
				context.Succeed(requirement);
			}

		}

    }
}
