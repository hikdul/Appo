
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Appo.Core.ObjectValues;
using Appo.Core.Exceptions;

namespace Appo.Test.ValuesObject
{
	[TestClass]
	public class EmailTest
	{

		[TestMethod]
		public void Email_Creation_Bad0()
		{
			string email = "main@hikduldev";
			//!: de este modo ingreso mi valor y puedo obtener la respuesata esacta, o el mensaje de respuesta
			var ex = Assert.ThrowsExactly<BusinesRuleException>(() =>
					{
					var em = new Email(email);
					});

			Assert.AreEqual($"The {nameof(email)} is not a valid email", ex.Message);
		}

		[TestMethod]
		public void Email_Creation_bad1()
		{
			string email = "mainhikdul.dev";

			var ex = Assert.ThrowsExactly<BusinesRuleException>(() =>
					{
					var em = new Email(email);
					});

			Assert.AreEqual($"The {nameof(email)} is not a valid email", ex.Message);
		}

		[TestMethod]
		public void Email_Creation_bad_null()
		{
			var ex = Assert.ThrowsExactly<BusinesRuleException>(() =>
					{
					var em = new Email(null);
					});
			Assert.AreEqual($"The email is required", ex.Message);
		}

		[TestMethod]
		public void Email_CreationOk()
		{
			string email = "main@hikdul.dev";
			Email em = new(email);

			Assert.AreEqual(em.Value, email);
		}

	}
}
