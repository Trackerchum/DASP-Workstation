using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace DASPWorkstation.Test
{
    [TestClass]
    public class DFTSpec
    {
        private Z_SpecHelper specHelper = new Z_SpecHelper();

        [TestMethod]
        public void dftFunctionMustReturnTheCorrectNumberOfValues()
        {
            var dft = new DFT();
            dft.N = 16;
            var x = new List<float>(new float[16]);
            var X = dft.PerformDFT(x);

            Assert.AreEqual(16, x.Count);
        }

        [TestMethod]
        public void dftFunctionMustReturnTheCorrectValues()
        {
            var dft = new DFT();
            dft.N = 16;
            var x = new List<float>(new float[] { 0.4f, 1.3066f, 1.1314f, 0.235f, 0.8f, 0.5412f, 0.5657f, 2.0457f, -0.4f, -1.3066f, -1.1314f, -0.235f, -0.8f, -0.5412f, -0.5657f, -2.0457f });
            var X = dft.PerformDFT(x);

            Assert.IsTrue(specHelper.AreApproximatelyEqual(X[0].Real, 0));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(X[0].Imaginary, 0));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(X[1].Real, 0));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(X[1].Imaginary, -8));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(X[2].Real, 0));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(X[2].Imaginary, 0));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(X[3].Real, 0));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(X[3].Imaginary, -6.4f));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(X[4].Real, 0));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(X[4].Imaginary, 0));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(X[5].Real, 0));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(X[5].Imaginary, -4.8f));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(X[6].Real, 0));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(X[6].Imaginary, 0));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(X[7].Real, 3.2f));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(X[7].Imaginary, 0));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(X[8].Real, 0));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(X[8].Imaginary, 0));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(X[9].Real, 3.2f));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(X[9].Imaginary, 0));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(X[10].Real, 0));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(X[10].Imaginary, 0));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(X[11].Real, 0));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(X[11].Imaginary, 4.8f));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(X[12].Real, 0));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(X[12].Imaginary, 0));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(X[13].Real, 0));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(X[13].Imaginary, 6.4f));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(X[14].Real, 0));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(X[14].Imaginary, 0));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(X[15].Real, 0));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(X[15].Imaginary, 8));
        }

        [TestMethod]
        public void dftFunctionShouldResetOnFurtherUse()
        {
            var dft = new DFT();
            dft.N = 16;
            var x = new List<float>(new float[] { 0.4f, 1.3066f, 1.1314f, 0.235f, 0.8f, 0.5412f, 0.5657f, 2.0457f, -0.4f, -1.3066f, -1.1314f, -0.235f, -0.8f, -0.5412f, -0.5657f, -2.0457f });
            var X = dft.PerformDFT(x);
            X = dft.PerformDFT(x);

            Assert.IsTrue(specHelper.AreApproximatelyEqual(X[0].Real, 0));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(X[0].Imaginary, 0));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(X[1].Real, 0));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(X[1].Imaginary, -8));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(X[2].Real, 0));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(X[2].Imaginary, 0));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(X[3].Real, 0));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(X[3].Imaginary, -6.4f));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(X[4].Real, 0));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(X[4].Imaginary, 0));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(X[5].Real, 0));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(X[5].Imaginary, -4.8f));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(X[6].Real, 0));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(X[6].Imaginary, 0));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(X[7].Real, 3.2f));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(X[7].Imaginary, 0));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(X[8].Real, 0));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(X[8].Imaginary, 0));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(X[9].Real, 3.2f));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(X[9].Imaginary, 0));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(X[10].Real, 0));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(X[10].Imaginary, 0));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(X[11].Real, 0));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(X[11].Imaginary, 4.8f));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(X[12].Real, 0));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(X[12].Imaginary, 0));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(X[13].Real, 0));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(X[13].Imaginary, 6.4f));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(X[14].Real, 0));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(X[14].Imaginary, 0));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(X[15].Real, 0));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(X[15].Imaginary, 8));
        }
    }
}
