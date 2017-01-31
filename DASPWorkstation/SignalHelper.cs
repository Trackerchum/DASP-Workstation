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
            _signals.Add(new SignalDefinition(signalDefinition.Amplitude, signalDefinition.Frequency, signalDefinition.Phase));
        }


        public List<SignalDefinition> GetValues()
        {
            return _signals;
        }


        public void UpdateValues(SignalDefinition signalDefinition, int n)
        {
            _signals[n].Amplitude = signalDefinition.Amplitude;
            _signals[n].Frequency = signalDefinition.Frequency;
            _signals[n].Phase = signalDefinition.Phase;
        }


        public void ClearValues()
        {
            _signals.Clear();
        }
    }
}
