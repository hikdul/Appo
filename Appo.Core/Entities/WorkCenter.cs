
using System;
using Appo.Core.ObjectValues;
using Appo.Core.Exceptions;

namespace Appo.Core.Entities
{
	public class WorkCenter
	{
		public Guid Id { get; set; }
		public string Name { get; private set; }
		public Direction? Direction { get; set; }
		//public Guid TenantId { get; set; } //TODO: esto lo dejamos para cuando trabajo con esta area

		#region created

		protected WorkCenter()
		{

		}

		public WorkCenter(string name, Direction? direction)
		{
			validationRules(name);
			this.Id = Guid.CreateVersion7();
			this.Name = name;
			this.Direction = direction;
		}

		#endregion

		#region Edit

		public void Up(string? name, Direction? direction)
		{
			UpName(name);
			UpDirection(direction);
		}

		private void UpName(string? name)
		{
			if(!string.IsNullOrWhiteSpace(name))
				this.Name = name;
		}

		private void UpDirection(Direction? direction)
		{
			if(direction != null && !string.IsNullOrWhiteSpace(direction.Value) )
				this.Direction = direction;
		}
		#endregion

		#region validationRules

		private void validationRules(string name)
		{
			if(string.IsNullOrWhiteSpace(name))
				throw new BusinesRuleException("the WorkCenter Name is required");
		}
		#endregion
	}
}
