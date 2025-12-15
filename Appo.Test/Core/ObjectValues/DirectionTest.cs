using Microsoft.VisualStudio.TestTools.UnitTesting;
using Appo.Core.ObjectValues;
using Appo.Core.Exceptions;

namespace Appo.Test.ValuesObject
{
	[TestClass]
	public class DirectionTest
	{
		[TestMethod]
		public void creation_badLatitude()
		{
			string dir = Guid.CreateVersion7().ToString();

			var ex = Assert.ThrowsExactly<BusinesRuleException>(() =>
					{
					var em = new Direction(dir, -200, 0);
					});

			Assert.AreEqual("The Latitud value is not valid",ex.Message);
		}

		[TestMethod]
		public void creation_badLongitude()
		{
			string dir = Guid.CreateVersion7().ToString();
			var ex = Assert.ThrowsExactly<BusinesRuleException>(() =>
					{
					var em = new Direction(dir, 0, 500);
					});

			Assert.AreEqual("The Longitud value is not valid",ex.Message);
		}

		[TestMethod]
		public void creation_badDirection()
		{
			var ex = Assert.ThrowsExactly<BusinesRuleException>(() =>
					{
					Direction direction = new Direction(null, 0, 0);
					});
			Assert.AreEqual("The Direction description is REQUIRED",ex.Message);
		}

		[TestMethod]
		public void CreationOk()
		{
			string dir = Guid.CreateVersion7().ToString();
			Direction direction = new Direction(dir, 70, 80);

			Assert.IsNotNull(direction);
			Assert.AreEqual(direction.Value, dir);
			Assert.AreEqual(direction.Latitud, 70);
			Assert.AreEqual(direction.Longitud, 80);
		}
	}
}

