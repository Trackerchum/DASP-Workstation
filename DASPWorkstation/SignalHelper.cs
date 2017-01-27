using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DASPWorkstation
{
    public class SignalHelper
    {
        private List<SignalDefinition> _signals = new List<SignalDefinition>();

        public void AddSine(SignalDefinition signalDefinition)
        {
            _signals.Add(new SignalDefinition(signalDefinition.Amplitude, signalDefinition.Frequency, signalDefinition.Phase, signalDefinition.SamplingRate));
            var signal = new SignalDefinition(signalDefinition.Amplitude, signalDefinition.Frequency, signalDefinition.Phase, signalDefinition.SamplingRate);
        }

        public List<SignalDefinition> GetValues()
        {
            return _signals; // returns list of signal coefficients/constants
        }


    }
}
