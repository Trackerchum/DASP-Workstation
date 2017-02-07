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
        public void ScaleFT_ListShouldBeLengthOfCanvasUnderLength()
        {
            Assert.AreEqual(0, 1);
        }

        [TestMethod]
        public void ScaleFT_ListShouldBeLengthOfCanvasOverLength()
        {
            Assert.AreEqual(0, 1);
        }

        [TestMethod]
        public void ScaleFT_ShouldReturnTheCorrectValues()
        {
            var ftPlotter = new FT_Plotter();
            int N = new Random().Next(48000);
            var FT = new List<float>(new float[N]);

            var res = ftPlotter.ScaleFT(FT, N);

            Assert.AreEqual(0, 1);
        }
    }
}
