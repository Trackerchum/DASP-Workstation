using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DASPWorkstation.Test
{
    [TestClass]
    public class SignalGeneratorSpec
    {
        private Z_SpecHelper specHelper = new Z_SpecHelper();

        [TestMethod]
        public void GenerateSignalShouldReturnTheCorrectNumberOfValuesBasedOnSamplingRate()
        {
            float amplitude = 1;
            float frequency = 1;
            float phase = 90;
            int samplingRate = new Random().Next(48000);
            var signalDefinitions = new List<SignalDefinition>()
            {
                new SignalDefinition(amplitude, frequency, phase)
            };

            var unit = new SignalGenerator();
            var res = unit.GenerateSignal(signalDefinitions, samplingRate);
            Assert.AreEqual(65536, res.Count);
        }

        [TestMethod]
        public void GenerateSignalShouldReturnTheCorrectValues()
        {
            float amplitude = 1;
            float frequency = 2;
            float phase = 0;
            int samplingRate = 8;
            bool failed = false;

            var signalDefinitions = new List<SignalDefinition>()
            {
                new SignalDefinition(amplitude, frequency, phase)
            };

            var unit = new SignalGenerator();
            var res = unit.GenerateSignal(signalDefinitions, samplingRate);

            Assert.IsTrue(specHelper.AreApproximatelyEqual(res[0], 0));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(res[1], 1));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(res[2], 0));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(res[3], -1));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(res[4], 0));

            Assert.AreEqual(failed, false);
            // http://docs.oracle.com/cd/E19957-01/806-3568/ncg_goldberg.html
        }

        [TestMethod]
        public void GenerateSignalShouldNotApplyOverTheTopOfPreviousSignal()
        {
            float amplitude = 1;
            float frequency = 2;
            float phase = 0;
            int samplingRate = 8;

            var signalDefinitions = new List<SignalDefinition>()
            {
                new SignalDefinition(amplitude, frequency, phase)
            };

            var unit = new SignalGenerator();
            unit.GenerateSignal(signalDefinitions, samplingRate);
            var res = unit.GenerateSignal(signalDefinitions, samplingRate);


            Assert.IsTrue(specHelper.AreApproximatelyEqual(res[0], 0));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(res[1], 1));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(res[2], 0));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(res[3], -1));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(res[4], 0));
        }
        
        [TestMethod]
        public void GenerateSignalShouldAddMultipleSignalsTogether()
        {
            float amplitude = 0.5F;
            float frequency = 2;
            float phase = 0;
            int samplingRate = 8;

            var signalDefinitions = new List<SignalDefinition>()
            {
                new SignalDefinition(amplitude, frequency, phase),
                new SignalDefinition(amplitude, frequency, phase)
            };

            var unit = new SignalGenerator();
            unit.GenerateSignal(signalDefinitions, samplingRate);
            var res = unit.GenerateSignal(signalDefinitions, samplingRate);

            Assert.IsTrue(specHelper.AreApproximatelyEqual(res[0], 0));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(res[1], 1));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(res[2], 0));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(res[3], -1));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(res[4], 0));
            // http://docs.oracle.com/cd/E19957-01/806-3568/ncg_goldberg.html
        }
    }
}
