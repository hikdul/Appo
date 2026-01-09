
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Appo.Core.ObjectValues;
using Appo.Core.Exceptions;
using Appo.Core.Entities;

namespace Appo.Test.Entities
{
	[TestClass]
	public class WorkCenterTest
	{
		[TestMethod]
		public void Created_bad()
		{

			var ex = Assert.ThrowsExactly<BusinesRuleException>(() =>
					{
					WorkCenter Flag = new(" ",null);
					});
			Assert.AreEqual("the WorkCenter Name is required", ex.Message);
		}

		[TestMethod]
		public void Created_Ok()
		{
			string name = Guid.NewGuid().ToString();
			WorkCenter Flag = new(name,null);
			Assert.AreEqual(name,Flag.Name);
			Assert.AreNotEqual(Guid.Empty,Flag.Id);
		}


		[TestMethod]
		public void Edit_whitNotEdit()
		{
			string name = Guid.NewGuid().ToString();
			WorkCenter Flag = new(name,null);
			Guid Id = Flag.Id;
			Assert.AreEqual(name, Flag.Name);
			Assert.AreEqual(Id, Flag.Id);

			Flag.Up(null,null);
			Assert.AreEqual(name, Flag.Name);
			Assert.AreEqual(Id, Flag.Id);
		}


		[TestMethod]
		public void Edit_Ok()
		{
			string name = Guid.NewGuid().ToString();
			WorkCenter Flag = new(name,null);
			Guid Id = Flag.Id;
			Assert.AreEqual(name, Flag.Name);
			Assert.IsNull(Flag.Direction);
			Assert.AreEqual(Id, Flag.Id);

			Direction dir = new(name);

			Flag.Up(null,dir);
			Assert.IsNotNull(Flag.Direction.Value);
			Assert.AreEqual(name, Flag.Direction.Value);
			Assert.AreEqual(name, Flag.Name);
			Assert.AreEqual(Id, Flag.Id);
		}


	}
}
