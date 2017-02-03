using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DASPWorkstation.Test
{
    [TestClass]
    public class SignalDefinitionSpec
    {
        [TestMethod]
        public void SignalToStringShouldReturnTheFormattedStringRepresentingTheSignal()
        {
            float a = new Random().Next(48000);
            float f = new Random().Next(48000);
            float p = new Random().Next(48000);
            int sr = new Random().Next(48000);

            var unit = new SignalDefinition(a, f, p);
            var res = unit.ToString(a, f, p);
            Assert.AreEqual($"{a}A | {f}Hz | {p}ph", res);
        }
    }
}
