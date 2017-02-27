using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace DASPWorkstation.Test
{
    [TestClass]
    public class FT_PlotterSpec
    {
        private FT_Plotter ftPlotter = new FT_Plotter();

        [TestMethod]
        public void ScaleFT_ShouldReturnTheCorrectNumberOfValuesUnderLength()
        {
            int N = new Random().Next(1269);
            var FT = new List<float>(new float[N]);
            var res = ftPlotter.ScaleFT(FT, N);

            Assert.AreEqual(N/2+1, res.Count);
        }

        [TestMethod]
        public void ScaleFT_ShouldReturnTheCorrectNumberOfValuesOverLength()
        {
            int N = 5000;
            var FT = new List<float>(new float[N]);
            var res = ftPlotter.ScaleFT(FT, N);

            Assert.AreEqual(1270, res.Count);
        }

        [TestMethod]
        public void ScaleFT_MaxValueShouldBeTwoHundred()
        {
            int N = new Random().Next(48000);
            var FT = new List<float>(new float[N]);
            FT[0] = 50;
            var res = ftPlotter.ScaleFT(FT, N);

            Assert.AreEqual(200, res.Max());
        }

        [TestMethod]
        public void ScaleFT_ShouldReturnTheCorrectValuesZero()
        {
            int N = 16;
            var FT = new List<float>(new float[] { 0, 8, 0, 6.4f, 0, 4.8f, 0, 3.2f, 0, 3.2f, 0, 4.8f, 0, 6.4f, 0, 8 });

            var res = ftPlotter.ScaleFT(FT, N);
            
            Assert.AreEqual(200, res[0]);
        }

        [TestMethod]
        public void ScaleFT_ShouldReturnTheCorrectValuesOne()
        {
            int N = 16;
            var FT = new List<float>(new float[] { 0, 8, 0, 6.4f, 0, 4.8f, 0, 3.2f, 0, 3.2f, 0, 4.8f, 0, 6.4f, 0, 8 });

            var res = ftPlotter.ScaleFT(FT, N);

            Assert.AreEqual(0, res[1]);
        }

        [TestMethod]
        public void ScaleFT_ShouldReturnTheCorrectValuesTwo()
        {
            int N = 16;
            var FT = new List<float>(new float[] { 0, 8, 0, 6.4f, 0, 4.8f, 0, 3.2f, 0, 3.2f, 0, 4.8f, 0, 6.4f, 0, 8 });

            var res = ftPlotter.ScaleFT(FT, N);
            
            Assert.AreEqual(200, res[2]);
        }

        [TestMethod]
        public void ScaleFT_ShouldReturnTheCorrectValuesThree()
        {
            int N = 16;
            var FT = new List<float>(new float[] { 0, 8, 0, 6.4f, 0, 4.8f, 0, 3.2f, 0, 3.2f, 0, 4.8f, 0, 6.4f, 0, 8 });

            var res = ftPlotter.ScaleFT(FT, N);
            
            Assert.AreEqual((((6.4 / 8) * 200) - 200) * -1, res[3]);
        }

        [TestMethod]
        public void ScaleFT_ShouldReturnTheCorrectValuesFour()
        {
            int N = 16;
            var FT = new List<float>(new float[] { 0, 8, 0, 6.4f, 0, 4.8f, 0, 3.2f, 0, 3.2f, 0, 4.8f, 0, 6.4f, 0, 8 });

            var res = ftPlotter.ScaleFT(FT, N);
            
            Assert.AreEqual(200, res[4]);
        }

        [TestMethod]
        public void ScaleFT_ShouldReturnTheCorrectValuesFive()
        {
            int N = 16;
            var FT = new List<float>(new float[] { 0, 8, 0, 6.4f, 0, 4.8f, 0, 3.2f, 0, 3.2f, 0, 4.8f, 0, 6.4f, 0, 8 });

            var res = ftPlotter.ScaleFT(FT, N);
            
            Assert.AreEqual((((4.8 / 8) * 200) - 200) * -1, res[5]);
        }

        [TestMethod]
        public void ScaleFT_ShouldReturnTheCorrectValuesSix()
        {
            int N = 16;
            var FT = new List<float>(new float[] { 0, 8, 0, 6.4f, 0, 4.8f, 0, 3.2f, 0, 3.2f, 0, 4.8f, 0, 6.4f, 0, 8 });

            var res = ftPlotter.ScaleFT(FT, N);
            
            Assert.AreEqual(200, res[6]);
        }

        [TestMethod]
        public void ScaleFT_ShouldReturnTheCorrectValuesSeven()
        {
            int N = 16;
            var FT = new List<float>(new float[] { 0, 8, 0, 6.4f, 0, 4.8f, 0, 3.2f, 0, 3.2f, 0, 4.8f, 0, 6.4f, 0, 8 });

            var res = ftPlotter.ScaleFT(FT, N);
            
            Assert.AreEqual((((3.2 / 8) * 200) - 200) * -1, res[7]);
        }

        [TestMethod]
        public void PrepDBForScaleMinValueShouldBeZero()
        {
            var XmagDB = new List<float>(new float[] { 0, -8, -50, -6.4f, -154.86f, -4.8f, 0, -3.2f, 0, -3.2f, 0, -4.8f, 0, -6.4f, 0, -8 });
            var res = ftPlotter.PrepDB(XmagDB);

            Assert.AreEqual(0, res.Min());
        }

        [TestMethod]
        public void PrepDBForScaleShouldReturnTheCorrectvalue()
        {
            var XmagDB = new List<float>(new float[] { 0, -8, -50, -6.4f, -154.86f, -4.8f, 0, -3.2f, 0, -3.2f, 0, -4.8f, 0, -6.4f, 0, -8 });
            var res = ftPlotter.PrepDB(XmagDB);

            Assert.AreEqual(154.86f, res[0]);
            Assert.AreEqual(-8 + 154.86f, res[1]);
            Assert.AreEqual(-50 + 154.86f, res[2]);
            Assert.AreEqual(-3.2f + 154.86f, res[7]);
        }
    }
}
