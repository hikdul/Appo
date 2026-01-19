
using Appo.Core.ObjectValues;
using Appo.Core.Exceptions;
using Appo.Core.Commons;



// Note: Posiblemente este usuario cresca y en ese momento se tenga que agregar algun elemento ya que el crecimiento se ara basado en los datos recojidos de la persona

namespace Appo.Core.Entities
{
	public class Person: AuditEnt
	{
		public Guid Id { get; set; }
		public string Name { get; private set; }
		public string? LastName { get; private set; }
		public Email? Email { get; set; } //TODO: que el constructo valide que exista al menos 1 de las 2 para guardar los datos...
		public PhoneNumber? PhoneNumber { get; set; }

		#region created
		protected Person()
		{

		}

		public Person(string name, string? lastName, string? email, string? phoneNumber)
		{
			ValidationRules(name, lastName, email, phoneNumber);
			this.Id = Guid.CreateVersion7();
			this.Name = name;
			this.LastName = null;
			this.LastName = lastName;
			if(!string.IsNullOrWhiteSpace(email))
				this.Email = new(email);
			if(!string.IsNullOrWhiteSpace(phoneNumber))
				this.PhoneNumber = new(phoneNumber);
		}
		#endregion


		#region Edit

		public void Up(string? name, string? lastName, string? email, string? phoneNumber)
		{
			//ValidationRules(name, lastName, email, phoneNumber);
			UpName(name);
			UpLastName(lastName);
			UpEmail(email);
			UpPhoneNumber(phoneNumber);

		}

		private void UpPhoneNumber(string phoneNumber)
		{
			if(!string.IsNullOrWhiteSpace(phoneNumber))
				this.PhoneNumber = new(phoneNumber);
		}

		private void UpEmail(string email)
		{
			if(!string.IsNullOrWhiteSpace(email))
				this.Email = new(email);
		}

		private void UpLastName(string lastname)
		{
			if(!string.IsNullOrWhiteSpace(lastname))
				this.LastName = LastName;
		}

		private void UpName(string name)
		{
			if(!string.IsNullOrWhiteSpace(name))
				this.Name = name;
		}

		#endregion


		#region ValidationRules

		private void ValidationRules(string name, string LastName, string? email, string? phoneNumber)
		{
			if(string.IsNullOrWhiteSpace(name))
				throw new BusinesRuleException($"The Name is required");
			if(string.IsNullOrWhiteSpace(email) && string.IsNullOrWhiteSpace(phoneNumber))
				throw new BusinesRuleException($"We need a mode for contact whit you! please add a Email Address or a PhoneNumber for contact you later!");
		}
		#endregion
	}
}
