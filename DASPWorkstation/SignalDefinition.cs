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
        public int SamplingRate { get; set; }

        public SignalDefinition(float amplitude, float frequency, float phase, int samplingRate)
        {
            Amplitude = amplitude;
            Frequency = frequency;
            Phase = phase;
            SamplingRate = samplingRate;
        }

        public string ToString(float amplitude, float frequency, float phase)
        {
            return $"{Amplitude}A | {Frequency}Hz | {Phase}ph";
        }
    }
}
