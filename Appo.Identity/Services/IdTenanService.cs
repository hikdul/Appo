using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Appo.Application.Contracts.Identity;
using Microsoft.Extensions.Options;

namespace Appo.Identity.Services
{
    public class IdTenanService: IIdTenantService
    {

        private readonly IHttpContextAccessor httpContextAccessor;
		public IdTenanService(IHttpContextAccessor _httpContextAccessor)
		{
		    this.httpContextAccessor = _httpContextAccessor;
		}

	    public Guid GetTenantId()
		{
            var httpContext = httpContextAccessor.HttpContext;

            if (httpContext is null)
            {
                return Guid.Empty;
            }

            var authTicket = DecryptAuthCookie(httpContext);

            if (authTicket is null)
            {
                return Guid.Empty;
            }

            var claimTenant = authTicket.Principal.Claims.FirstOrDefault(x => x.Type == Constants.CLAIMTENANTID);

            if (claimTenant is null)
            {
                return Guid.Empty;
            }

			string str =  claimTenant.Value;

			if(!string.IsNullOrWhiteSpace(str))
			{
				return Guid.Parse(str);
			}
            return Guid.Empty;
        }

        private static AuthenticationTicket? DecryptAuthCookie(HttpContext httpContext)
        {
            var opt = httpContext.RequestServices
                .GetRequiredService<IOptionsMonitor<CookieAuthenticationOptions>>()
                .Get("Identity.Application");

            var cookie = opt.CookieManager.GetRequestCookie(httpContext, opt.Cookie.Name!);

            return opt.TicketDataFormat.Unprotect(cookie);
        }

    }
}
