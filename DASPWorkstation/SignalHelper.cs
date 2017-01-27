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

        public string AddSine(SignalDefinition signalDefinition)
        {
            _signals.Add(new SignalDefinition(signalDefinition.Amplitude, signalDefinition.Frequency, signalDefinition.Phase, signalDefinition.SamplingRate));
            var signal = new SignalDefinition(signalDefinition.Amplitude, signalDefinition.Frequency, signalDefinition.Phase, signalDefinition.SamplingRate);
            string sineString = signal.ToString(signalDefinition.Amplitude, signalDefinition.Frequency, signalDefinition.Phase);
            return sineString;
        }

        public List<SignalDefinition> GetValues()
        {
            return _signals; // returns list of signal coefficients/constants
        }


    }
}
