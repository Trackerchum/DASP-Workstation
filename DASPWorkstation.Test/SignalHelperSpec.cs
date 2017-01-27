using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace DASPWorkstation.Test
{
    [TestClass]
    public class SignalHelperSpec
    {        
        [TestMethod]
        public void GetSineWavesShouldReturnAllSignalsAddedSoFar()
        {
            float a = new Random().Next(48000);
            float f = new Random().Next(48000);
            float p = new Random().Next(48000);
            int sr = new Random().Next(48000);
            var signalDefinition1 = new SignalDefinition(a, f, p, sr);

            float a2 = new Random().Next(48000);
            float f2 = new Random().Next(48000);
            float p2 = new Random().Next(48000);
            int sr2 = new Random().Next(48000);
            var signalDefinition2 = new SignalDefinition(a2, f2, p2, sr2);

            var unit = new SignalHelper();
            unit.AddSine(signalDefinition1);
            unit.AddSine(signalDefinition2);
            var res = unit.GetValues();
            Assert.AreEqual(2, res.Count());
            Assert.AreEqual(a, res[0].Amplitude);
            Assert.AreEqual(f, res[0].Frequency);
            Assert.AreEqual(p, res[0].Phase);

            Assert.AreEqual(a2, res[1].Amplitude);
            Assert.AreEqual(f2, res[1].Frequency);
            Assert.AreEqual(p2, res[1].Phase);
        }
    }
}
