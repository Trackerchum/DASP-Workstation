using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DASP_WorkstationWPF;

namespace DASP_WorkstationWPF_test
{

    [TestClass]
    public class SignalGeneratorTests
    {
        [TestMethod]
        public void ItShouldReturnAValueFromGenerateSignal()
        {
            var unit = new SignalGenerator();
            var res = unit.GenerateSignal(1);
            Assert.IsNotNull(res);
            Assert.AreEqual(2, res);
        }

        [TestMethod]
        public void ItShouldReturnAValueFromGenerateSignal2()
        {
            var unit = new SignalGenerator();
            var res = unit.GenerateSignal(3);
            Assert.IsNotNull(res);
            Assert.AreEqual(6, res);
        }

        //Extreme Programming Explained
    }
}
