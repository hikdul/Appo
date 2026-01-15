using System;
using Appo.Core.Exceptions;

namespace Appo.Core.Entities
{
	//TODO: Manejar el lista de empresas en el cual este usuario es cliente
	//TODO: permitir de algun modo enlazar datos tanto como cliente como usuario
    public class Customer
    {
		//public Guid Id { get; set; }
		// TODO: person y TenantId tiene que ser el inicio
		public Guid TenantId { get; private set; } //?: para este caso la empresa
		public Guid PersonId { get; private set; }
		public Person Person { get; private set; }
		public DateTime? LastVisit { get; private set; }


		private Customer()
		{
		}

		// vamos a trabajar lo mas simple posible...
		public Customer(Guid TenantId, Guid PersonId)
		{
			ValidationRules(TenantId, PersonId);
			this.TenantId = TenantId;
			this.PersonId = PersonId;
			this.LastVisit = null;
		}

		public void Up_LastVisit(DateTime time)
		{
			this.LastVisit = time;
		}

		private void ValidationRules(Guid TenantId, Guid PersonId)
		{
			if(Guid.Empty == PersonId)
				throw new BusinesRuleException("We Can't created this user");
			if(Guid.Empty == TenantId)
				throw new BusinesRuleException("The Company of the clinent its no assing");
		}
	}
}
