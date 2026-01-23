using Microsoft.AspNetCore.Authorization;

namespace Appo.Identity.Security
{
    public record HasAllowRequirement: IAuthorizationRequirement
    {
		public Alloweds allow { get; }

		public HasAllowRequirement(Alloweds _allow)
		{
		    this.allow = _allow;
		}
    }
}
