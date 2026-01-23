using System.Data;
using Microsoft.AspNetCore.Authorization;

namespace Appo.Identity.Security
{
	/// <summary>
	/// Con esta clase manipulo el dinamismo de los permisos, y de este modo es mas simple el darle a quitarle permisos a un usuario para no tener que manipular los diferentes tipos.
	/// </sumary>
	public class CanDoAttribute: AuthorizeAttribute
	{

		public CanDoAttribute( Alloweds _allow)
		{
			allows = _allow;
		}

		public Alloweds allows {
			get {
				if(Enum.TryParse(typeof(Alloweds), Policy!.Substring(Appo.Identity.Services.Constants.PREFIXPOLITICIE.Length),ignoreCase: true, out var allow))
				{
					return (Alloweds)allows;
				}
				return Alloweds.belong;
			}
			set{
				Policy = $"{Appo.Identity.Services.Constants.PREFIXPOLITICIE}{value.ToString()}";
			}
		}

	}


} 
