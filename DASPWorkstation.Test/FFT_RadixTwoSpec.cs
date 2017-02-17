using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DASPWorkstation.Test
{
    [TestClass]
    public class FFT_RadixTwoSpec
    {
        private FFT_RadixTwo fft = new FFT_RadixTwo();

        [TestMethod]
        public void BitReversalMustReturnTheCorrectNumberOfValues()
        {
            int resolution = 2;
            for (int n = 1; n < 15; n++)
            {
                var actual = fft.BitReversal((int)Math.Pow(resolution, n));
                Assert.AreEqual((int)Math.Pow(resolution, n), actual.Count);
            }
        }

        [TestMethod]
        public void BitReversalMustThrowExceptionIfInvalidNumberPassed()
        {
            var exceptionThrown = false;
            try
            {
                var actual = fft.BitReversal(3);
            }
            // TODO: Create a custom exception type and test for that
            catch(Exception e)
            {
                exceptionThrown = true;
            }

            Assert.IsTrue(exceptionThrown);
        }

        [TestMethod]
        public void BitReversalMustReturnTheCorrectValuesEight()
        {
            int N = 8;
            var actual = fft.BitReversal(N);
            var expected = new List<int>(new int[] { 0, 4, 2, 6, 1, 5, 3, 7 });

            for (int n = 0; n < 8; n++)
            {
                Assert.AreEqual(expected[n], actual[n]);
            }
        }

        [TestMethod]
        public void BitReversalMustReturnTheCorrectValuesSixteen()
        {
            int N = 16;
            var actual = fft.BitReversal(N);
            var expected = new List<int>(new int[] { 0, 8, 4, 12, 2, 10, 6, 14, 1, 9, 5, 13, 3, 11, 7, 15 });

            for (int n = 0; n < 16; n++)
            {
                Assert.AreEqual(expected[n], actual[n]);
            }
        }

        [TestMethod]
        public void BitReversalMustReturnTheCorrectValuesThirtyTwo()
        {
            int N = 32;
            var actual = fft.BitReversal(N);
            var expected = new List<int>(new int[] { 0, 16, 8, 24, 4, 20, 12, 28, 2, 18, 10, 26, 6, 22, 14, 30, 1, 17, 9, 25, 5, 21, 13, 29, 3, 19, 11, 27, 7, 23, 15, 31 });

            for (int n = 0; n < 32; n++)
            {
                Assert.AreEqual(expected[n], actual[n]);
            }
        }

        [TestMethod]
        public void BitReversalShouldNotApplyOverItself()
        {
            int N = 32;
            var actual = fft.BitReversal(N);
            actual = fft.BitReversal(N);
            var expected = new List<int>(new int[] { 0, 16, 8, 24, 4, 20, 12, 28, 2, 18, 10, 26, 6, 22, 14, 30, 1, 17, 9, 25, 5, 21, 13, 29, 3, 19, 11, 27, 7, 23, 15, 31 });

            for (int n = 0; n < 32; n++)
            {
                Assert.AreEqual(expected[n], actual[n]);
            }
        }

        [TestMethod]
        public void BitReverseSignalShouldBitReverseSignal()
        {
            var BR_Index = new List<int>(new int[] { 0, 8, 4, 12, 2, 10, 6, 14, 1, 9, 5, 13, 3, 11, 7, 15 });
            var x = new List<float>(new float[] { 0.4f, 1.3066f, 1.1314f, 0.235f, 0.8f, 0.5412f, 0.5657f, 2.0457f, -0.4f, -1.3066f, -1.1314f, -0.235f, -0.8f, -0.5412f, -0.5657f, -2.0457f });
            var signalBR = fft.BitReverseSignal(BR_Index, x);

            for (int n = 0; n < x.Count; n++)
            {
                Assert.AreEqual(x[BR_Index[n]], signalBR[n]);
            }
        }

        [TestMethod]
        public void FFT_FirstStageMustReturnTheCorrectNumberOfValues()
        {
            var BR_Index = new List<int>(new int[] { 0, 8, 4, 12, 2, 10, 6, 14, 1, 9, 5, 13, 3, 11, 7, 15 });
            var x = new List<float>(new float[] { 0.4f, 1.3066f, 1.1314f, 0.235f, 0.8f, 0.5412f, 0.5657f, 2.0457f, -0.4f, -1.3066f, -1.1314f, -0.235f, -0.8f, -0.5412f, -0.5657f, -2.0457f });
            var signalBR = fft.BitReverseSignal(BR_Index, x);
            var expected = new List<float>(new float[] { 0, 0.8f, 0, 1.6f, 0, 2.2628f, 0, 1.1314f, 0, 2.6132f, 0, 1.0824f, 0, 0.47f, 0, 4.0914f });
            var X_FirstStage = fft.FirstStage(signalBR);

            for (int n = 0; n < 16; n++)
            {
                Assert.AreEqual(expected[n], X_FirstStage[n]);
            }
        }

            //[TestMethod]
            //public void FFT_RadixTwoFirstStageMustReturnTheCorrectNumberOfValues()
            //{

            //}

            //[TestMethod]
            //public void FFT_RadixTwoFirstStageMustReturnTheCorrectValues()
            //{

            //}

            //[TestMethod]
            //public void FFT_RadixTwoMustReturnTheCorrectNumberOfValues()
            //{

            //}
        }
}
