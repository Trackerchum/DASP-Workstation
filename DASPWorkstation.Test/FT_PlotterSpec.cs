using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace DASPWorkstation.Test
{
    [TestClass]
    public class FT_PlotterSpec
    {
        [TestMethod]
        public void ScaleFT_ShouldReturnTheCorrectNumberOfValuesUnderLength()
        {
            var ftPlotter = new FT_Plotter();
            int N = new Random().Next(1269);
            var FT = new List<float>(new float[N]);
            var res = ftPlotter.ScaleFT(FT, N);

            Assert.AreEqual(N, res.Count);
        }

        [TestMethod]
        public void ScaleFT_ShouldReturnTheCorrectNumberOfValuesOverLength()
        {
            var ftPlotter = new FT_Plotter();
            int N = 5000;
            var FT = new List<float>(new float[N]);
            var res = ftPlotter.ScaleFT(FT, N);

            Assert.AreEqual(1270, res.Count);
        }

        [TestMethod]
        public void ScaleFT_MaxValueShouldBeTwoHundred()
        {
            var ftPlotter = new FT_Plotter();
            int N = new Random().Next(48000);
            var FT = new List<float>(new float[N]);
            FT[0] = 50;
            var res = ftPlotter.ScaleFT(FT, N);

            Assert.AreEqual(200, res.Max());
        }

        [TestMethod]
        public void ScaleFT_ShouldReturnTheCorrectValues()
        {
            var ftPlotter = new FT_Plotter();
            int N = 16;
            var FT = new List<float>(new float[] { 0, 8, 0, 6.4f, 0, 4.8f, 0, 3.2f, 0, 3.2f, 0, 4.8f, 0, 6.4f, 0, 8 });

            var res = ftPlotter.ScaleFT(FT, N);

            Assert.AreEqual(200, res[1]);
            Assert.AreEqual(200, res[15]);
            Assert.AreEqual((6.4 / 8) * 200, res[3]);
            Assert.AreEqual((6.4 / 8) * 200, res[13]);
            Assert.AreEqual((4.8 / 8) * 200, res[5]);
            Assert.AreEqual((4.8 / 8) * 200, res[11]);
        }
    }
}
