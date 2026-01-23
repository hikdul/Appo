
using System.Net;
using  Microsoft.AspNetCore.Authorization ;

namespace Appo.Identity.Security
{
	public class HasAllowPolicyProvider: IAuthorizationPolicyProvider
	{
		public Task<AuthorizationPolicy> GetDefaultPolicyAsync()
		{
			return Task.FromResult(new AuthorizationPolicyBuilder("Identity.Application").RequireAuthenticatedUser().Build());
		}

		public Task<AuthorizationPolicy?> GetFallbackPolicyAsync()
		{
			return Task.FromResult<AuthorizationPolicy?>(null!);
		}

		public Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
		{
			if(policyName.StartsWith(Identity.Services.Constants.PREFIXPOLITICIE, StringComparison.OrdinalIgnoreCase)
					&& Enum.TryParse(typeof(Alloweds), policyName.Substring(Identity.Services.Constants.PREFIXPOLITICIE.Length), out var allowObj))
			{
				var allow = (Alloweds)allowObj;
				var policy = new AuthorizationPolicyBuilder("Identity.Application");
				policy.AddRequirements(new HasAllowRequirement(allow));
				return Task.FromResult<AuthorizationPolicy?>(policy.Build());
			}
			//! hanlet para buscan en DB

			//! esto construlle el trabajo
			return Task.FromResult<AuthorizationPolicy?>(null!);
		}

	}
}
