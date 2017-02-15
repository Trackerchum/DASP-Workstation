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
        public void BitReversalMustReturnTheCorrectNumberOfValuesTwo()
        {
            int N = 2;
            var actual = fft.BitReversal(N);

            Assert.AreEqual(N, actual.Count);
        }

        [TestMethod]
        public void BitReversalMustReturnTheCorrectNumberOfValuesFour()
        {
            int N = 4;
            var actual = fft.BitReversal(N);

            Assert.AreEqual(N, actual.Count);
        }

        [TestMethod]
        public void BitReversalMustReturnTheCorrectNumberOfValuesEight()
        {
            int N = 8;
            var actual = fft.BitReversal(N);

            Assert.AreEqual(N, actual.Count);
        }

        [TestMethod]
        public void BitReversalMustReturnTheCorrectNumberOfValuesSixteen()
        {
            int N = 16;
            var actual = fft.BitReversal(N);

            Assert.AreEqual(N, actual.Count);
        }

        [TestMethod]
        public void BitReversalMustReturnTheCorrectNumberOfValuesThirtyTwo()
        {
            int N = 32;
            var actual = fft.BitReversal(N);

            Assert.AreEqual(N, actual.Count);
        }

        [TestMethod]
        public void BitReversalMustReturnTheCorrectNumberOfValuesSixtyFour()
        {
            int N = 64;
            var actual = fft.BitReversal(N);

            Assert.AreEqual(N, actual.Count);
        }

        [TestMethod]
        public void BitReversalMustReturnTheCorrectNumberOfValuesOneTwoEight()
        {
            int N = 128;
            var actual = fft.BitReversal(N);

            Assert.AreEqual(N, actual.Count);
        }

        [TestMethod]
        public void BitReversalMustReturnTheCorrectNumberOfValuesTwoFiveSix()
        {
            int N = 256;
            var actual = fft.BitReversal(N);

            Assert.AreEqual(N, actual.Count);
        }

        [TestMethod]
        public void BitReversalMustReturnTheCorrectNumberOfValuesFiveOneTwo()
        {
            int N = 512;
            var actual = fft.BitReversal(N);

            Assert.AreEqual(N, actual.Count);
        }

        [TestMethod]
        public void BitReversalMustReturnTheCorrectNumberOfValuesTenTwentyFour()
        {
            int N = 1024;
            var actual = fft.BitReversal(N);

            Assert.AreEqual(N, actual.Count);
        }

        [TestMethod]
        public void BitReversalMustReturnTheCorrectNumberOfValuesTwentyFortyEight()
        {
            int N = 2048;
            var actual = fft.BitReversal(N);

            Assert.AreEqual(N, actual.Count);
        }

        [TestMethod]
        public void BitReversalMustReturnTheCorrectNumberOfValuesFortyNinetySix()
        {
            int N = 4096;
            var actual = fft.BitReversal(N);

            Assert.AreEqual(N, actual.Count);
        }

        [TestMethod]
        public void BitReversalMustReturnTheCorrectNumberOfValuesEightyOneNinetyTwo()
        {
            int N = 8192;
            var actual = fft.BitReversal(N);

            Assert.AreEqual(N, actual.Count);
        }

        [TestMethod]
        public void BitReversalMustReturnTheCorrectNumberOfValuesSixteenXXX()
        {
            int N = 16384;
            var actual = fft.BitReversal(N);

            Assert.AreEqual(N, actual.Count);
        }

        [TestMethod]
        public void BitReversalMustReturnTheCorrectNumberOfValuesEightyThirtyTwoXXX()
        {
            int N = 32768;
            var actual = fft.BitReversal(N);

            Assert.AreEqual(N, actual.Count);
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
