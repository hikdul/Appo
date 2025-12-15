

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Appo.Core.ObjectValues;
using Appo.Core.Exceptions;
using Appo.Core.Entities;

namespace Appo.Test.Entities
{
	[TestClass]
	public class PersonTest
	{

		[TestMethod]
		public void Created_badContactinfo()
		{
			var ex = Assert.ThrowsExactly<BusinesRuleException>(() =>
					{
					Person p = new("", "", "algo", "");
					});
			Assert.AreEqual("The Name is required", ex.Message);
		}

		[TestMethod]
		public void Created_badName()
		{
			string name = Guid.NewGuid().ToString();


			var ex = Assert.ThrowsExactly<BusinesRuleException>(() =>
					{
					Person p = new(name, "", null, null);
					});
			Assert.AreEqual("We need a mode for contact whit you! please add a Email Address or a PhoneNumber for contact you later!", ex.Message);
		}

		[TestMethod]
		public void Created_ok()
		{
			string name = Guid.NewGuid().ToString();
			string email = $"{name}@algo.ve";

			Person p = new(name,name,email,null);

			Assert.AreEqual(name, p.Name);
			Assert.AreEqual(name, p.LastName);
			Assert.AreEqual(email, p.Email.Value);

		}

		[TestMethod]
		public void Up_notUpAnything()
		{

			string name = Guid.NewGuid().ToString();
			string email = $"{name}@algo.ve";

			Person p = new(name,name,email,null);


			Assert.AreEqual(name, p.Name);
			Assert.AreEqual(name, p.LastName);
			Assert.AreEqual(email, p.Email.Value);

			p.Up(null,null,null,null);
			Assert.AreEqual(name, p.Name);
			Assert.AreEqual(name, p.LastName);
			Assert.AreEqual(email, p.Email.Value);
		}


		public void Up_AddPhoneNumber()
		{
			string name = Guid.NewGuid().ToString();
			string email = $"{name}@algo.ve";
			string phoneNumber = "123456456";

			Person p = new(name,name,email,null);
			Assert.AreEqual(name, p.Name);
			Assert.AreEqual(name, p.LastName);
			Assert.AreEqual(email, p.Email.Value);
			Assert.IsNull(p.PhoneNumber.Value);

			p.Up(null,null,null,phoneNumber);
			Assert.AreEqual(name, p.Name);
			Assert.AreEqual(name, p.LastName);
			Assert.AreEqual(email, p.Email.Value);
			Assert.AreEqual(phoneNumber, p.PhoneNumber.Value);
		}

	}
}

