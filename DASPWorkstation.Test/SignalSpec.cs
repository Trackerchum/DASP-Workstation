using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DASPWorkstation.Test
{
    [TestClass]
    public class SignalSpec
    {
        [TestMethod]
        public void ShouldDoSomething()
        {
            var mockSignalDefinition = new SignalDefinition(1, 2, 3, 4);
            var mockResult = new List<float>()
            {
                10,
                9,
                8,
                7
            };
            var mockSignalGenerator = new Mock<ISignalGenerator>();
            mockSignalGenerator.Setup(sg => sg.GenerateSignal(mockSignalDefinition)).Returns(mockResult);

            var unit = new Signal(mockSignalDefinition, mockSignalGenerator.Object);
            Assert.AreEqual(unit.Waveform, mockResult);
        }
    }
}
