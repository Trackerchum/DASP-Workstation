using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace DASPWorkstation.Test
{
    [TestClass]
    public class ValidatorSpec
    {
        [TestMethod]
        public void ValidatorShouldRejectEmptyAmplitudeField()
        {
            var validator = new Validator();
            string a = null;
            string f = "345";
            string p = "345";
            var statusCode = validator.Validate(a, f, p);

            Assert.AreEqual(Validator.ValidatorStatusCode.AMPLITUDE_IS_NULL, statusCode);
        }

        [TestMethod]
        public void ValidatorShouldRejectEmptyFrequencyField()
        {
            var validator = new Validator();
            string a = "345";
            string f = null;
            string p = "345";
            var statusCode = validator.Validate(a, f, p);

            Assert.AreEqual(Validator.ValidatorStatusCode.FREQUENCY_IS_NULL, statusCode);
        }

        [TestMethod]
        public void ValidatorShouldRejectEmptyPhaseField()
        {
            var validator = new Validator();
            string a = "345";
            string f = "345";
            string p = null;
            var statusCode = validator.Validate(a, f, p);

            Assert.AreEqual(Validator.ValidatorStatusCode.PHASE_IS_NULL, statusCode);
        }

        [TestMethod]
        public void ValidatorShouldRejectNonNumericAmplitude()
        {
            var validator = new Validator();
            string a = "34g5";
            string f = "345";
            string p = "345";
            var statusCode = validator.Validate(a, f, p);

            Assert.AreEqual(Validator.ValidatorStatusCode.AMPLITUDE_NOT_NUMERIC, statusCode);
        }

        [TestMethod]
        public void ValidatorShouldRejectNonNumericFrequency()
        {
            var validator = new Validator();
            string a = "345";
            string f = "34g5";
            string p = "345";
            var statusCode = validator.Validate(a, f, p);

            Assert.AreEqual(Validator.ValidatorStatusCode.FREQUENCY_NOT_NUMERIC, statusCode);
        }

        [TestMethod]
        public void ValidatorShouldRejectNonNumericPhase()
        {
            var validator = new Validator();
            string a = "345";
            string f = "345";
            string p = "34g5";
            var statusCode = validator.Validate(a, f, p);

            Assert.AreEqual(Validator.ValidatorStatusCode.PHASE_NOT_NUMERIC, statusCode);
        }

        [TestMethod]
        public void ValidatorShouldRejectAmplitudeBelowParameters()
        {
            var validator = new Validator();
            string a = "0";
            string f = "345";
            string p = "345";
            var statusCode = validator.Validate(a, f, p);

            Assert.AreEqual(Validator.ValidatorStatusCode.AMPLITUDE_NOT_WITHIN_PARAMETERS, statusCode);
        }

        [TestMethod]
        public void ValidatorShouldRejectAmplitudeAboveParameters()
        {
            var validator = new Validator();
            string a = "345";
            string f = "345";
            string p = "345";
            var statusCode = validator.Validate(a, f, p);

            Assert.AreEqual(Validator.ValidatorStatusCode.AMPLITUDE_NOT_WITHIN_PARAMETERS, statusCode);
        }

        [TestMethod]
        public void ValidatorShouldRejectFrequencyBelowParameters()
        {
            var validator = new Validator();
            string a = "1";
            string f = "-96001";
            string p = "345";
            var statusCode = validator.Validate(a, f, p);

            Assert.AreEqual(Validator.ValidatorStatusCode.FREQUENCY_NOT_WITHIN_PARAMETERS, statusCode);
        }

        [TestMethod]
        public void ValidatorShouldRejectFrequencyAboveParameters()
        {
            var validator = new Validator();
            string a = "1";
            string f = "96001";
            string p = "345";
            var statusCode = validator.Validate(a, f, p);

            Assert.AreEqual(Validator.ValidatorStatusCode.FREQUENCY_NOT_WITHIN_PARAMETERS, statusCode);
        }

        [TestMethod]
        public void ValidatorShouldRejectPhaseBelowParameters()
        {
            var validator = new Validator();
            string a = "1";
            string f = "-96000";
            string p = "-3601";
            var statusCode = validator.Validate(a, f, p);

            Assert.AreEqual(Validator.ValidatorStatusCode.PHASE_NOT_WITHIN_PARAMETERS, statusCode);
        }

        [TestMethod]
        public void ValidatorShouldRejectPhaseAboveParameters()
        {
            var validator = new Validator();
            string a = "1";
            string f = "96000";
            string p = "3601";
            var statusCode = validator.Validate(a, f, p);

            Assert.AreEqual(Validator.ValidatorStatusCode.PHASE_NOT_WITHIN_PARAMETERS, statusCode);
        }
    }
}
