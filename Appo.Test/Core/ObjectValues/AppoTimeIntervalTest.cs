using Microsoft.VisualStudio.TestTools.UnitTesting;
using Appo.Core.ObjectValues;
using Appo.Core.Exceptions;

namespace Appo.Test.ValuesObject
{
    [TestClass]
	public class AppoTimeIntervalTest
	{
		
        [TestMethod]
        public void Creation_BadData()
        {
            var hoy = DateTime.Now;
			var ex = Assert.ThrowsExactly<BusinesRuleException>(() =>
					{
            		var flag = new AppoTimeInterval(hoy.AddHours(1), hoy);
					});
			Assert.AreEqual("The time interval is not valid", ex.Message);
        }


        [TestMethod]
        public void Creation_ok()
        {
            var hoy = DateTime.Now;
            var flag = new AppoTimeInterval(hoy.AddHours(-1), hoy);

			Assert.AreEqual(hoy.AddHours(-1), flag.Start);
			Assert.AreEqual(hoy, flag.Finish);
        }
	}
}
