using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace DASPWorkstation.Test
{
    [TestClass]
    public class SignalPlotterSpec
    {
        [TestMethod]
        public void ScaledSignalMaxValueShouldNotExceedTwoHundredOne()
        {
            float a = 1;
            float f = new Random().Next(48000);
            float p = new Random().Next(48000);
            int samplingRate = new Random().Next(48000);
            List<float> signal = new List<float>();

            for (int n = 0; n <= 1270; n++)
            {
                signal.Add(a * (float)Math.Sin(2 * Math.PI * n * f/samplingRate + p));
            }

            var unit = new SignalPlotter();
            var res = unit.ScaleSignal(signal, samplingRate);

            Assert.IsTrue(res.Max() <= 201);
        }

        [TestMethod]
        public void ScaledSignalListShouldBeLengthOfCanvas()
        {
            float a = 1;
            float f = new Random().Next(48000);
            float p = new Random().Next(48000);
            int samplingRate = new Random().Next(48000);
            List<float> signal = new List<float>();

            for (int n = 0; n <= 1270; n++)
            {
                signal.Add(a * (float)Math.Sin(2 * Math.PI * n * f / samplingRate + p));
            }

            var unit = new SignalPlotter();
            var res = unit.ScaleSignal(signal, samplingRate);

            Assert.AreEqual(res.Count, 1270);
        }
        

    }
}
