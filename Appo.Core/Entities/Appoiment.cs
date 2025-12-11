using System;
using Appo.Core.ObjectValues;
using Appo.Core.Exceptions;
using Appo.Core.Helpers;

namespace Appo.Core.Entities
{
	public class Appoiment
	{
		public Guid Id { get; set; }

		public AppoTimeInterval TimeInterval { get; set; }

		public Guid CustomerId { get; set; }
		public Customer? Customer { get; set; }

		public Guid? WorkerId { get; set; }
		public User? Worker { get; set; }

		public AppoimentStatus Status { get; set; }

		public string? CustomerRequest { get; set; }

		public string? WorkDescription { get; set; }

		// => esto es el chisme
		public string? Gossip { get; set; }

		#region created
		public Appoiment(Guid customerId, DateTime start, DateTime finish,Guid WorkerId ,string? CustomerRequest)
		{
			validateTimeIntelval(start, finish);
			this.Id = Guid.CreateVersion7();
			this.TimeInterval = new(start, finish);
			this.CustomerId = customerId;
			this.Status = AppoimentStatus.Reserved;
			if(string.IsNullOrWhiteSpace(CustomerRequest))
				this.CustomerRequest = CustomerRequest;
			if(Guid.Empty != WorkerId && WorkerId != null)
				this.WorkerId = WorkerId;
		}
		#endregion

		#region Edit

		public void CancelAppoiment()
		{
			// TODO: aca indicar quien genero la cancelacion de la cita mediante las reglas que se generen en ese momento
			if(this.Status != AppoimentStatus.Reserved)
				throw new BusinesRuleException("Only can cancel a reserved Appoiment");
			this.Status = AppoimentStatus.Cancel;
		}

		public void CompleteAppoiment()
		{

			// TODO: aca verificar que todos los datos se completen para cerrar la cita.
			if(this.Status != AppoimentStatus.Reserved)
				throw new BusinesRuleException("Only can complete a reserved Appoiment");
			this.Status = AppoimentStatus.Complete;
		}

		public void Reschedule(DateTime start, DateTime finish)
		{
			if(this.Status != AppoimentStatus.Reserved)
				throw new BusinesRuleException("Only can reschedule a reserved Appoiment");
			validateTimeIntelval(start,finish);
			this.TimeInterval = new(start, finish);
		}
		#endregion

		#region helpers
		private void validateTimeIntelval(DateTime start, DateTime finish) {

			DateTime hoy = DateTime.UtcNow.AddHours(-12);
			if(hoy < start)
				throw new BusinesRuleException("The strart time is older");

			if(hoy < finish)
				throw new BusinesRuleException("The finish time is older");
		}
		#endregion

	}
}
