
using Appo.Core.Commons;

namespace Appo.Core.Entities
{
    public class Partner: AuditEnt, ITenantEnt
    {
		//public Guid Id { get; set; } // Note: se permite trabajar como entidad individual para facilitar la obtencion de datos para las empresas que seran los clientes que pagan
		// TODO: TenantId y personId deben de ser el mismisimo ID
		public Guid TenantId { get; set; } //?: Por ahora aca va el valor de la empresa 
		public Guid PersonId { get; set; }
		public Person Person { get; set; }
		//?: aca deberia de ir la empresa y tambien los permisos que tiene este usuario dentro de la empresa.. incluso si es el jefazo(quien paga)

    	// TODO: maneja el lista de empresas al cual pertenece y a su ves los permisos
    	// TODO: verificar que aca el Email si o si sea obligatorio (Por ahora)
    	// TODO: Manejara el TenandId desde aca; pero eso se define luego

		private Partner()
		{
		    
		}

		public Partner(Guid TenantId, Guid personId)
		{
			this.TenantId = TenantId;
			this.PersonId = personId;
		}

		private void ValidationRules(string name, string lastName, string? email, string? phoneNumber)
		{
		}
	}
}
