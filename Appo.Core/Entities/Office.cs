
using System;
using Appo.Core.ObjectValues;
using Appo.Core.Exceptions;

namespace Appo.Core.Entities
{
    public class Office
    {
    	public Guid Id { get; set; }
		public string Name { get; private set; }
		public Direction? Direction { get; set; }
		//public Guid TenantId { get; set; } //TODO: esto lo dejamos para cuando trabajo con esta area

#region created
		protected Office()
		{
		    
		}

		public Office(string name, Direction? direction)
		{
			validationRules(name);
			this.Id = Guid.CreateVersion7();
			this.Name = name;
			this.Direction = direction;
		}
#endregion



#region Edit
		protected void Up(string? name, Direction? direction)
		{
			if(direction != null && string.IsNullOrWhiteSpace(direction.Value) )
				this.Direction = direction;
			if(string.IsNullOrWhiteSpace(name))
				this.Name = name;
		}

		


#endregion


#region validationRules

		private void validationRules(string name)
		{
			if(string.IsNullOrWhiteSpace(name))
				throw new BusinesRuleException("the Office Name is required");
		}
#endregion
    }
}
