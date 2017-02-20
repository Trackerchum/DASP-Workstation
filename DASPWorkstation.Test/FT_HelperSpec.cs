using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace DASPWorkstation.Test
{
    [TestClass]
    public class FT_HelperSpec
    {
        private Z_SpecHelper specHelper = new Z_SpecHelper();

        [TestMethod]
        public void AbsFunctionMustReturnTheCorrectValue()
        {
            var ftHelper = new FT_Helper();
            var complex = new Complex(3, 4);
            var complex2 = new Complex(-3, -4);
            var abs = ftHelper.Abs(complex);
            var abs2 = ftHelper.Abs(complex2);

            Assert.AreEqual(5, abs);
            Assert.AreEqual(5, abs2);
        }

        [TestMethod]
        public void DbFunctionMustReturnTheCorrectNumberOfValues()
        {
            var ftHelper = new FT_Helper();
            int N = new Random().Next(48000);
            var Xmag = new List<float>(new float[N]);
            var XmagDB = ftHelper.ConvertToDB(Xmag, N);

            Assert.AreEqual(N, XmagDB.Count);
        }

        [TestMethod]
        public void DbFunctionMustReturnTheCorrectValues()
        {
            var ftHelper = new FT_Helper();
            int N = 16;
            var Xmag = new List<float>(new float[] { 0, 8, 0, 6.4f, 0, 4.8f, 0, 3.2f, 0, 3.2f, 0, 4.8f, 0, 6.4f, 0, 8 });
            var XmagDB = ftHelper.ConvertToDB(Xmag, N);

            Assert.IsTrue(specHelper.AreApproximatelyEqual(XmagDB[1], 0));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(XmagDB[3], -1.9382f));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(XmagDB[5], -4.437f));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(XmagDB[7], -7.9588f));
        }

        [TestMethod]
        public void ComplexMultiplicationMustReturnTheCorrectValueA()
        {
            Complex complex1 = new Complex(0.707f, 0.707f);
            Complex complex2 = new Complex(1.414f, 1.414f);

            var ftHelper = new FT_Helper();
            Complex result = ftHelper.ComplexMultiplication(complex1, complex2);

            Assert.IsTrue(specHelper.AreApproximatelyEqual(0, result.Real));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(2, result.Imaginary));
        }

        [TestMethod]
        public void ComplexMultiplicationMustReturnTheCorrectValueB()
        {
            Complex complex1 = new Complex(-0.707f, 0.707f);
            Complex complex2 = new Complex(1.414f, -1.414f);

            var ftHelper = new FT_Helper();
            Complex result = ftHelper.ComplexMultiplication(complex1, complex2);

            Assert.IsTrue(specHelper.AreApproximatelyEqual(0, result.Real));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(2, result.Imaginary));
        }

        [TestMethod]
        public void ComplexMultiplicationMustReturnTheCorrectValueC()
        {
            Complex complex1 = new Complex(0, 1);
            Complex complex2 = new Complex(-1.414f, 0);

            var ftHelper = new FT_Helper();
            Complex result = ftHelper.ComplexMultiplication(complex1, complex2);

            Assert.IsTrue(specHelper.AreApproximatelyEqual(0, result.Real));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(-1.414f, result.Imaginary));
        }

        [TestMethod]
        public void ComplexMultiplicationMustReturnTheCorrectValueD()
        {
            Complex complex1 = new Complex(-0.707f, -0.707f);
            Complex complex2 = new Complex(1.414f, 1.414f);

            var ftHelper = new FT_Helper();
            Complex result = ftHelper.ComplexMultiplication(complex1, complex2);

            Assert.IsTrue(specHelper.AreApproximatelyEqual(0, result.Real));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(-2, result.Imaginary));
        }

        [TestMethod]
        public void ComplexMultiplicationMustReturnTheCorrectValueE()
        {
            Complex complex1 = new Complex(0.707f, -0.707f);
            Complex complex2 = new Complex(1.414f, -1.414f);

            var ftHelper = new FT_Helper();
            Complex result = ftHelper.ComplexMultiplication(complex1, complex2);

            Assert.IsTrue(specHelper.AreApproximatelyEqual(0, result.Real));
            Assert.IsTrue(specHelper.AreApproximatelyEqual(-2, result.Imaginary));
        }
    }
}
