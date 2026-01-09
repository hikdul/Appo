using System;

namespace Appo.Core.Entities
{
	//TODO: Manejar el lista de empresas en el cual este usuario es cliente
	//TODO: permitir de algun modo enlazar datos tanto como cliente como usuario
    public class Customer
    {
		public Guid Id { get; set; }
		public Guid TenantId { get; private set; } //?: para este caso la empresa
		public Guid PersonId { get; private set; }
		public Person Person { get; private set; }
		public DateTime? LastVisit { get; private set; }


		private Customer()
		{
		}

		// para crear de manera limpia con todo los datos
		public Customer(Guid TenantId,string name, string lastName, string? email, string? phoneNumber) 
		{
		    ValidationRules(name, lastName, email, phoneNumber);
			this.Id = Guid.CreateVersion7();
			this.TenantId = TenantId;
			this.Person = new( name,  lastName,  email,  phoneNumber);
			this.PersonId = this.Person.Id;
			this.LastVisit = DateTime.Now;
		}

		// para crear solo ingresando a la personal cuando ya existe
		public Customer(Guid PersonId)
		{
			this.PersonId = this.Person.Id;
		}

		public void Up_LastVisit(DateTime time)
		{
			this.LastVisit = time;
		}

		private void ValidationRules(string name, string lastName, string? email, string? phoneNumber)
		{
		}
	}
}
