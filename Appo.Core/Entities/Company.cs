
using System;

namespace Appo.Core.Entities
{
	public class Company
	{
		public Guid Id { get; set; }
		public string Name { get; private set; }
		public string? Description { get; private set; }

		private Company()
		{

		}

		#region created
		public Company(string name, string? description)
		{
			ValidationRules(name, Description);
			this.Id = Guid.CreateVersion7();
			this.Name = name;
			if(string.IsNullOrWhiteSpace(description))
				this.Description = description;
		}
		#endregion

		#region edit

		public void Up(string? name, string? description)
		{
			setName(name);
			setDescription(description);
		}

		private void setName(string name)
		{
			if(string.IsNullOrWhiteSpace(name))
				this.Name = name;
		}

		private void setDescription(string description)
		{
			if(string.IsNullOrWhiteSpace(description))
				this.Description = description;
		}

		#endregion


		#region ValidationRules

		private void ValidationRules(string name, string? Description)
		{
			if(string.IsNullOrWhiteSpace(name))
				throw new BusinesRuleException($"the {typeof(name)} is required");
		}
		#endregion
	}
}
