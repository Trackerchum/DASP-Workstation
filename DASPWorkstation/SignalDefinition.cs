using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DASPWorkstation
{
    public class SignalDefinition
    {
        public float Amplitude { get; set; }
        public float Frequency { get; set; }
        public float Phase { get; set; }

        public SignalDefinition(float amplitude, float frequency, float phase)
        {
            Amplitude = amplitude;
            Frequency = frequency;
            Phase = phase;
        }

        public string ToString(float amplitude, float frequency, float phase)
        {
            return $"{Amplitude}A | {Frequency}Hz | {Phase}ph";
        }
    }
}
