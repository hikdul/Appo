using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Appo.Identity.Security
{
    public static class AuthorizationServicesExtensions
    {
		/// <summary>
		/// Con esta funcio se puede validar en duro y us usuarios tiene permmitido ejecutar alguna accion...
		/// No se si sera util a menos no por ahora.
		/// </summary>
		public static async Task<bool> CanDoAuth(IAuthorizationService authService, ClaimsPrincipal user, Alloweds allow)
		{
			//?: aca como valido o como filtro para saber que el usuario esta logeado.. o confio en el token valido
			var politicyName = $"{Appo.Identity.Services.Constants.PREFIXPOLITICIE}{allow}";
			var result = await authService.AuthorizeAsync(user,politicyName);
			return result.Succeeded;
		}
    }
}
