using System;

namespace Appo.Core.Entities
{
	//TODO: Manejar el lista de empresas en el cual este usuario es cliente
	//TODO: permitir de algun modo enlazar datos tanto como cliente como usuario
    public class Customer: Person
    {
		public Guid Id { get; set; }

		private Customer(): base()
		{
		    
		}

		public Customer(string name, string lastName, string? email, string? phoneNumber): base( name,  lastName,  email,  phoneNumber)
		{
		    ValidationRules(name, lastName, email, phoneNumber);
			this.Id = Guid.CreateVersion7();
		}

		private void ValidationRules(string name, string lastName, string? email, string? phoneNumber)
		{
		}
	}
}
