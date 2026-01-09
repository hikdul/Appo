
using Appo.Core.Exceptions;
using Appo.Core.ObjectValues;
using Appo.Core.Entities;
using System.Text;

namespace Appo.Core.Builders
{
	public sealed class AppoimentBuilder
	{
		// Obligatorios
		private readonly Guid _customerId;
		private readonly DateTime _start;
		private readonly DateTime _finish;

		// Opcionales
		private Guid? _workerId;
		private Guid? _workCenterId;
		private string? _customerRequest;
		private string? _workDescription;
		private string? _gossip;

		private AppoimentBuilder(Guid customerId, DateTime start, DateTime finish)
		{
			_customerId = customerId;
			_start = start;
			_finish = finish;
		}

		public static AppoimentBuilder Create(Guid customerId, DateTime start, DateTime finish)
			=> new(customerId, start, finish);



		public AppoimentBuilder WithWorker(Guid workerId)
		{
			if (workerId == Guid.Empty)
				throw new BusinesRuleException("WorkerId is invalid");

			_workerId = workerId;
			return this;
		}


		public AppoimentBuilder WithWorkCenter(Guid workCenterId)
		{
			if (workCenterId == Guid.Empty)
				throw new BusinesRuleException("WorkCenterId is invalid");

			_workCenterId = workCenterId;
			return this;
		}

		public AppoimentBuilder WithCustomerRequest(string? request)
		{
			if (!string.IsNullOrWhiteSpace(request))
				_customerRequest = request;

			return this;
		}

		public AppoimentBuilder WithWorkDescription(string? description)
		{
			if (!string.IsNullOrWhiteSpace(description))
				_workDescription = description;

			return this;
		}

		public AppoimentBuilder WithGossip(string? gossip)
		{
			_gossip = gossip;
			return this;
		}


		public Appoiment Build()
		{
			var appoiment = new Appoiment(_customerId, _start, _finish, null, null);

			if (_workerId.HasValue)
				appoiment.AssingWorker(_workerId.Value);

			if (_workCenterId.HasValue)
				appoiment.AssingWorkCenter(_workCenterId.Value);

			if (!string.IsNullOrWhiteSpace(_customerRequest))
				appoiment.AssingCustomerRequest(_customerRequest);

			if (!string.IsNullOrWhiteSpace(_workDescription))
				appoiment.AssingWorkDescription(_workDescription);

			if (!string.IsNullOrWhiteSpace(_gossip))
				appoiment.AssingGossip(_gossip);

			return appoiment;
		}
	}

}
