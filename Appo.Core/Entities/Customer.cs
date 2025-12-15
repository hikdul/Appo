using System;

namespace Appo.Core.Entities
{
	//TODO: Manejar el lista de empresas en el cual este usuario es cliente
	//TODO: permitir de algun modo enlazar datos tanto como cliente como usuario
    public class Customer
    {
		public Guid Id { get; set; }
		public Guid PersonId { get; set; }
		public Person Person { get; set; }

		private Customer()
		{
		    
		}

		// para crear de manera limpia con todo los datos
		public Customer(string name, string lastName, string? email, string? phoneNumber) 
		{
		    ValidationRules(name, lastName, email, phoneNumber);
			this.Id = Guid.CreateVersion7();
			this.Person = new( name,  lastName,  email,  phoneNumber);
			this.PersonId = this.Person.Id;
		}

		// para crear solo ingresando a la personal cuando ya existe
		public Customer(Guid PersonId)
		{
			this.Id = Guid.CreateVersion7();
			this.PersonId = this.Person.Id;
		}

		private void ValidationRules(string name, string lastName, string? email, string? phoneNumber)
		{
		}
	}
}
