using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DASPWorkstation
{
    public class SignalGenerator : ISignalGenerator
    {
        public List<float> GenerateSignal(SignalDefinition signalDefinition)
        {
            var res = new List<float>();
            for (int n = 0; n < signalDefinition.SamplingRate; n++)
            {
                res.Add(signalDefinition.Amplitude * (float)(Math.Sin(2 * Math.PI * n * signalDefinition.Frequency / signalDefinition.SamplingRate + (signalDefinition.Phase * (Math.PI / 180)))));
            }
            return res;
        }
    }

    public interface ISignalGenerator
    {
        List<float> GenerateSignal(SignalDefinition signalDefinition);
    }
}
