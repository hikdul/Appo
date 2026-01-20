
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Appo.Application.Contracts.Identity;

namespace Appo.Identity.Services
{
    public class UsersServices: IUsersServices
    {

        private readonly IHttpContextAccessor httpContextAccessor;

        public UsersServices(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public string GetUserId()
        {
            return httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier)!;
        }
    }
}
