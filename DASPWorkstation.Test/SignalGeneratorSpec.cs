using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DASPWorkstation.Test
{
    [TestClass]
    public class SignalGeneratorSpec
    {
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
            Assert.AreEqual(samplingRate, res.Count);
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

            if ((Math.Sqrt(res[0] * res[0])) > 0.000000000000001) // 10^-15
            {
                failed = true;
            }
            if ((Math.Sqrt((res[1] - 1) * (res[1] - 1))) > 0.000000000000001)
            {
                failed = true;
            }
            if ((Math.Sqrt(res[2] * res[2])) > 0.000000000000001)
            {
                failed = true;
            }
            if ((Math.Sqrt((res[3] + 1) * (res[3] + 1))) > 0.000000000000001)
            {
                failed = true;
            }
            if ((Math.Sqrt(res[4] * res[4])) > 0.000000000000001)
            {
                failed = true;
            }

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


            Assert.IsTrue(AreApproximatelyEqual(res[0], 0));
            // Assert.IsTrue(res[0] > -0.001 && res[0] < 0.001);
            Assert.IsTrue(res[1] > 0.999 && res[1] < 1.001);
            Assert.IsTrue(res[2] > -0.001 && res[2] < 0.001);
            Assert.IsTrue(res[3] < -0.999 && res[3] > -1.001);
            Assert.IsTrue(res[4] > -0.001 && res[4] < 0.001);
            // http://docs.oracle.com/cd/E19957-01/806-3568/ncg_goldberg.html
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

            Assert.IsTrue(res[0] > -0.001 && res[0] < 0.001);
            Assert.IsTrue(res[1] > 0.999 && res[1] < 1.001);
            Assert.IsTrue(res[2] > -0.001 && res[2] < 0.001);
            Assert.IsTrue(res[3] < -0.999 && res[3] > -1.001);
            Assert.IsTrue(res[4] > -0.001 && res[4] < 0.001);
            // http://docs.oracle.com/cd/E19957-01/806-3568/ncg_goldberg.html
        }

        private bool AreApproximatelyEqual(float actual, float expected)
        {
            return false;
        }
    }
}
