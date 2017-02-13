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

            Assert.AreEqual(N/2, res.Count);
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
        public void ScaleFT_ShouldReturnTheCorrectValuesZero()
        {
            var ftPlotter = new FT_Plotter();
            int N = 16;
            var FT = new List<float>(new float[] { 0, 8, 0, 6.4f, 0, 4.8f, 0, 3.2f, 0, 3.2f, 0, 4.8f, 0, 6.4f, 0, 8 });

            var res = ftPlotter.ScaleFT(FT, N);
            
            Assert.AreEqual(200, res[0]);
        }

        [TestMethod]
        public void ScaleFT_ShouldReturnTheCorrectValuesOne()
        {
            var ftPlotter = new FT_Plotter();
            int N = 16;
            var FT = new List<float>(new float[] { 0, 8, 0, 6.4f, 0, 4.8f, 0, 3.2f, 0, 3.2f, 0, 4.8f, 0, 6.4f, 0, 8 });

            var res = ftPlotter.ScaleFT(FT, N);

            Assert.AreEqual(0, res[1]);
        }

        [TestMethod]
        public void ScaleFT_ShouldReturnTheCorrectValuesTwo()
        {
            var ftPlotter = new FT_Plotter();
            int N = 16;
            var FT = new List<float>(new float[] { 0, 8, 0, 6.4f, 0, 4.8f, 0, 3.2f, 0, 3.2f, 0, 4.8f, 0, 6.4f, 0, 8 });

            var res = ftPlotter.ScaleFT(FT, N);
            
            Assert.AreEqual(200, res[2]);
        }

        [TestMethod]
        public void ScaleFT_ShouldReturnTheCorrectValuesThree()
        {
            var ftPlotter = new FT_Plotter();
            int N = 16;
            var FT = new List<float>(new float[] { 0, 8, 0, 6.4f, 0, 4.8f, 0, 3.2f, 0, 3.2f, 0, 4.8f, 0, 6.4f, 0, 8 });

            var res = ftPlotter.ScaleFT(FT, N);
            
            Assert.AreEqual((((6.4 / 8) * 200) - 200) * -1, res[3]);
        }

        [TestMethod]
        public void ScaleFT_ShouldReturnTheCorrectValuesFour()
        {
            var ftPlotter = new FT_Plotter();
            int N = 16;
            var FT = new List<float>(new float[] { 0, 8, 0, 6.4f, 0, 4.8f, 0, 3.2f, 0, 3.2f, 0, 4.8f, 0, 6.4f, 0, 8 });

            var res = ftPlotter.ScaleFT(FT, N);
            
            Assert.AreEqual(200, res[4]);
        }

        [TestMethod]
        public void ScaleFT_ShouldReturnTheCorrectValuesFive()
        {
            var ftPlotter = new FT_Plotter();
            int N = 16;
            var FT = new List<float>(new float[] { 0, 8, 0, 6.4f, 0, 4.8f, 0, 3.2f, 0, 3.2f, 0, 4.8f, 0, 6.4f, 0, 8 });

            var res = ftPlotter.ScaleFT(FT, N);
            
            Assert.AreEqual((((4.8 / 8) * 200) - 200) * -1, res[5]);
        }

        [TestMethod]
        public void ScaleFT_ShouldReturnTheCorrectValuesSix()
        {
            var ftPlotter = new FT_Plotter();
            int N = 16;
            var FT = new List<float>(new float[] { 0, 8, 0, 6.4f, 0, 4.8f, 0, 3.2f, 0, 3.2f, 0, 4.8f, 0, 6.4f, 0, 8 });

            var res = ftPlotter.ScaleFT(FT, N);
            
            Assert.AreEqual(200, res[6]);
        }

        [TestMethod]
        public void ScaleFT_ShouldReturnTheCorrectValuesSeven()
        {
            var ftPlotter = new FT_Plotter();
            int N = 16;
            var FT = new List<float>(new float[] { 0, 8, 0, 6.4f, 0, 4.8f, 0, 3.2f, 0, 3.2f, 0, 4.8f, 0, 6.4f, 0, 8 });

            var res = ftPlotter.ScaleFT(FT, N);
            
            Assert.AreEqual((((3.2 / 8) * 200) - 200) * -1, res[7]);
        }
    }
}
