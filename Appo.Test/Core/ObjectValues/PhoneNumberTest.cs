using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;
using Appo.Core.ObjectValues;
using Appo.Core.Exceptions;

namespace Appo.Test.ValuesObject
{
	[TestClass]
	public class PhoneNumberTest
	{

		[TestMethod]
		public void creation_nullNumber()
		{
			string number = null;
			var ex = Assert.ThrowsExactly<BusinesRuleException>(() =>
					{
					var phn = new PhoneNumber(number);
					});

			Assert.AreEqual("The PhoneNumber is required ", ex.Message);
		}

		[TestMethod]
		public void creation_noNumber()
		{
			string number = "abc123";
			var ex = Assert.ThrowsExactly<BusinesRuleException>(() =>
					{
					var phn = new PhoneNumber(number);
					});

			Assert.AreEqual("The entry is no a valid PhoneNumber.", ex.Message);
		}

		[TestMethod]
		public void creation_ok()
		{
			string number = "123456789";
			var ent = new PhoneNumber(number);
			Assert.IsNotNull(ent);
			Assert.AreEqual(number, ent.Value);
		}
	}

}
