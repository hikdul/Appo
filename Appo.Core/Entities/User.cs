
namespace Appo.Core.Entities
{
    public class User: Person
    {
		public Guid Id { get; set; }
    	// TODO: maneja el lista de empresas al cual pertenece y a su ves los permisos
    	// TODO: verificar que aca el Email si o si sea obligatorio (Por ahora)
    	// TODO: Manejara el TenandId desde aca; pero eso se define luego

		private User():base()
		{
		    
		}

		public User(string name, string lastName, string? email, string? phoneNumber): base(name,  lastName,  email,  phoneNumber)
		{
		    ValidationRules(name, lastName, email, phoneNumber);
			this.Id = Guid.CreateVersion7();
		}

		private void ValidationRules(string name, string lastName, string? email, string? phoneNumber)
		{
		}
	}
}
