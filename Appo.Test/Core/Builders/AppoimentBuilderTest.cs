using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Appo.Core.ObjectValues;
using Appo.Core.Exceptions;
using Appo.Core.Entities;
using Appo.Core.Builders;
using Appo.Core.Helpers;

namespace Appo.Test.Builders {

	[TestClass]
	public class AppoimentBuilderTests{

		private static DateTime Start => DateTime.Now.AddHours(2);
		private static DateTime Finish => DateTime.Now.AddHours(3);

		[TestMethod]
		public void Build_WithRequiredFields_ShouldCreateReservedAppoiment()
		{
			Guid ValidCustomerId = Guid.CreateVersion7();
			// Aurrange & Act
			var appoiment = AppoimentBuilder
				.Create(ValidCustomerId, Start, Finish)
				.Build();

			// Assert
			Assert.IsNotNull(appoiment);
			Assert.AreEqual(AppoimentStatus.Reserved, appoiment.Status);
			Assert.IsNull(appoiment.WorkerId);
			Assert.IsNull(appoiment.OfficeId);
			Assert.AreEqual(appoiment.CustomerId, ValidCustomerId);
		}



		[TestMethod]
		public void Build_WithWorkerAndOffice_ShouldAssignCorrectly()
		{

			Guid ValidCustomerId = Guid.CreateVersion7();
			Guid ValidWorkerId = Guid.CreateVersion7();
			Guid ValidOfficeId = Guid.CreateVersion7();

			var appoiment = AppoimentBuilder
				.Create(ValidCustomerId, Start, Finish)
				.WithWorker(ValidWorkerId)
				.WithOffice(ValidOfficeId)
				.Build();

			Assert.AreEqual(ValidWorkerId, appoiment.WorkerId);
			Assert.AreEqual(ValidOfficeId, appoiment.OfficeId);
		}

		[TestMethod]
		public void Build_WithInvalidWorker_ShouldThrowException()
		{

			var start = DateTime.UtcNow.AddHours(-25);
			var finish = DateTime.UtcNow.AddHours(1);
			Guid ValidCustomerId = Guid.CreateVersion7();

			var ex = Assert.Throws<BusinesRuleException>(() =>
					{
					var build = AppoimentBuilder
					.Create(ValidCustomerId, start, finish)
					.WithWorker(Guid.Empty)
					.Build();
					});

			Assert.AreEqual("WorkerId is invalid", ex.Message);

		}

		[TestMethod]
		public void Build_WithInvalidDates_ShouldThrowException()
		{
			Guid ValidCustomerId = Guid.CreateVersion7();


			var start = DateTime.UtcNow.AddHours(3);
			var finish = DateTime.UtcNow.AddHours(1);

			var ex = Assert.Throws<BusinesRuleException>(() =>{
					AppoimentBuilder
					.Create(ValidCustomerId, start, finish)
					.Build();
					});
			Assert.AreEqual("The time interval is not valid", ex.Message);
		}

		[TestMethod]
		public void Build_WithGossip_ShouldAssignValue()
		{

			Guid ValidCustomerId = Guid.CreateVersion7();
			var gossip = "Cliente conoce al técnico de atras 👀";

			var appoiment = AppoimentBuilder
				.Create(ValidCustomerId, Start, Finish)
				.WithGossip(gossip)
				.Build();

			Assert.AreEqual(gossip, appoiment.Gossip);
		}
	}

}
