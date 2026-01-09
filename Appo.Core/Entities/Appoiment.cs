using System;
using Appo.Core.ObjectValues;
using Appo.Core.Exceptions;
using Appo.Core.Helpers;

namespace Appo.Core.Entities
{
	//TODO: Verificar si aca no se puede trabajar con un patron builder
	//TODO: que tambien me permita ir agregando elementos a partir de actualizacion
	//TODO: que genere una validacion inicial, y valla validando cada particular a medida que se agrega para que trabaje continuamente.
	public class Appoiment
	{
		public Guid Id { get; set; }

		public AppoTimeInterval TimeInterval { get; private set; }

		public Guid CustomerId { get; private set; }
		public Person? Customer { get; private set; }

		public Guid? WorkerId { get; private set; }
		public Person? Worker { get; private set; }

		public Guid? WorkCenterId { get; private set; }
		public WorkCenter? WorkCenter { get; private set; }

		public AppoimentStatus Status { get; private set; }

		public string? CustomerRequest { get; private set; }

		public string? WorkDescription { get; private set; }
		// => esto es el chisme
		public string? Gossip { get; private set; }

		#region created
		private Appoiment()
		{
		}

		internal Appoiment(Guid customerId, DateTime start, DateTime finish,Guid? WorkerId ,string? CustomerRequest)
		{
			validateTimeIntelval(start, finish);
			this.Id = Guid.CreateVersion7();
			this.CustomerId = customerId;
			this.TimeInterval = new(start, finish);
			this.Status = AppoimentStatus.Reserved;
			if(!string.IsNullOrWhiteSpace(CustomerRequest))
				this.CustomerRequest = CustomerRequest;
			if(Guid.Empty != WorkerId && WorkerId != null)
				this.WorkerId = WorkerId;
		}
		#endregion

		#region Setters Opcionals

		internal void AssingWorker(Guid workerId)
		{
			if(workerId == Guid.Empty)
				throw new BusinesRuleException("Not Valid Worker");
			this.WorkerId = workerId;
		}

		internal void AssingWorkCenter(Guid WorkCenterId)
		{
			if(WorkCenterId == Guid.Empty)
				throw new BusinesRuleException("Not Valid WorkCenter");
			this.WorkCenterId = WorkCenterId;
		}

		internal void AssingCustomerRequest(string request)
		{
			if(!string.IsNullOrWhiteSpace(request))
				this.CustomerRequest = request;
		}

		internal void AssingWorkDescription(string workDescription)
		{
			if(!string.IsNullOrWhiteSpace(workDescription))
				this.WorkDescription = workDescription;
		}

		internal void AssingGossip(string gossip)
		{
			if(!string.IsNullOrWhiteSpace(gossip))
				this.Gossip = gossip;
		}

		#endregion

		#region State Edit

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
			if( start < hoy)
				throw new BusinesRuleException("The strart time is older");

			if(finish < hoy)
				throw new BusinesRuleException("The finish time is older");
		}
		#endregion

	}
}
