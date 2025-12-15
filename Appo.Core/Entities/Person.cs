
using Appo.Core.ObjectValues;
using Appo.Core.Exceptions;


namespace Appo.Core.Entities
{
	public class Person
	{
		public string Name { get; private set; }
		public string? LastName { get; private set; }
		public Email? Email { get; set; } //TODO: que el constructo valide que exista al menos 1 de las 2 para guardar los datos...
		public PhoneNumber? PhoneNumber { get; set; }

		#region created
		protected Person()
		{

		}

		public Person(string name, string lastName, string? email, string? phoneNumber)
		{

			ValidationRules(name, lastName, email, phoneNumber);
			this.Name = name;
			this.LastName = lastName;
			if(!string.IsNullOrWhiteSpace(email))
				this.Email = new(email);
			if(!string.IsNullOrWhiteSpace(phoneNumber))
				this.PhoneNumber = new(phoneNumber);
		}
		#endregion


		#region Edit

		protected void Up(string? name, string? lastName, string? email, string? phoneNumber)
		{
			//ValidationRules(name, lastName, email, phoneNumber);
			SetName(name);
			SetLastName(lastName);
			SetEmail(email);
			SetPhoneNumber(phoneNumber);

		}

		private void SetPhoneNumber(string phoneNumber)
		{
			if(string.IsNullOrWhiteSpace(phoneNumber))
				this.PhoneNumber = new(phoneNumber);
		}

		private void SetEmail(string email)
		{
			if(string.IsNullOrWhiteSpace(email))
				this.Email = new(email);
		}

		private void SetLastName(string lastname)
		{
			if(string.IsNullOrWhiteSpace(lastname))
				this.LastName = LastName;
		}

		private void SetName(string name)
		{
			if(string.IsNullOrWhiteSpace(name))
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
