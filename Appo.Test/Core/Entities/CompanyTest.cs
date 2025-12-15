
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Appo.Core.ObjectValues;
using Appo.Core.Exceptions;
using Appo.Core.Entities;


namespace Appo.Test.Entities
{
	[TestClass]
    public class CompanyTest
    {

		[TestMethod]
		public void Created_EmptyName()
		{
            //string name = Guid.NewGuid().ToString();
			var ex = Assert.ThrowsExactly<BusinesRuleException>(() =>
					{
					Company Flag = new(" ",null);
					});
			Assert.AreEqual("the Name of the Company is required",ex.Message);
		}

		[TestMethod]
		public void Created_nullName()
		{
            //string name = Guid.NewGuid().ToString();
			var ex = Assert.ThrowsExactly<BusinesRuleException>(() =>
					{
					Company Flag = new(null,null);
					});
			Assert.AreEqual("the Name of the Company is required",ex.Message);
		}

		[TestMethod]
		public void Created_ok()
		{
            string name = Guid.NewGuid().ToString();
			Company Flag = new(name,null);
			Assert.AreEqual(name,Flag.Name);
			Assert.AreNotEqual(Guid.Empty, Flag.Id);
		}

		[TestMethod]
		public void Edit_whitNotEdit()
		{
            string name = Guid.NewGuid().ToString();
			Company Flag = new(name,null);
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
			Company Flag = new(name,null);
			Guid Id = Flag.Id;
			Assert.AreEqual(name, Flag.Name);
			Assert.IsNull(Flag.Description);
			Assert.AreEqual(Id, Flag.Id);

			Flag.Up(null,name);
			Assert.IsNotNull(Flag.Description);
			Assert.AreEqual(name, Flag.Description);
			Assert.AreEqual(name, Flag.Name);
			Assert.AreEqual(Id, Flag.Id);
		}

	}
}
