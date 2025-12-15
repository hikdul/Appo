
namespace Appo.Core.Entities
{
    public class User
    {
		public Guid Id { get; set; }
		public Guid PersonId { get; set; }
		public Person Person { get; set; }
		//?: aca deberia de ir la empresa y tambien los permisos que tiene este usuario dentro de la empresa.. incluso si es el jefazo(quien paga)

    	// TODO: maneja el lista de empresas al cual pertenece y a su ves los permisos
    	// TODO: verificar que aca el Email si o si sea obligatorio (Por ahora)
    	// TODO: Manejara el TenandId desde aca; pero eso se define luego

		private User():base()
		{
		    
		}

		public User(string name, string lastName, string? email, string? phoneNumber) 
		{
		    ValidationRules(name, lastName, email, phoneNumber);
			this.Person = new(name,  lastName,  email,  phoneNumber);
			this.Id = Guid.CreateVersion7();
			this.PersonId = this.Person.Id;
		}

		public User(Guid personId)
		{
			this.Id = Guid.CreateVersion7();
			this.PersonId = personId;
		}

		private void ValidationRules(string name, string lastName, string? email, string? phoneNumber)
		{
		}
	}
}
