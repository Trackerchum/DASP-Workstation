using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DASPWorkstation.Test
{
    [TestClass]
    public class FT_HelperSpec
    {
        [TestMethod]
        public void AbsFunctionMustReturnTheCorrectValue()
        {
            var ftHelper = new FT_Helper();
            var complex = new Complex(3, 4);
            var complex2 = new Complex(-3, -4);
            var abs = ftHelper.Abs(complex);
            var abs2 = ftHelper.Abs(complex2);

            Assert.AreEqual(5, abs);
            Assert.AreEqual(5, abs2);
        }

        [TestMethod]
        public void DbFunctionMustReturnTheCorrectValue()
        {

        }
    }
}
