using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DASPWorkstation
{
    public class SignalGenerator : ISignalGenerator
    {
        private SignalHelper _signalHelper = new SignalHelper();

        public List<float> GenerateSignal(List<SignalDefinition> signalParameters)
        {
            var res = new List<float>();
            for (int x = 0; x > signalParameters.Count; x++)
            {
                for (int n = 0; n < signalParameters[0].SamplingRate; n++)
                {
                    res.Add(signalParameters[x].Amplitude * (float)(Math.Sin(2 * Math.PI * n * signalParameters[x].Frequency / signalParameters[x].SamplingRate + (signalParameters[x].Phase * (Math.PI / 180)))));
                }
            }
            return res;
        }
    }

    public interface ISignalGenerator
    {
        List<float> GenerateSignal(List<SignalDefinition> signalParameters);
    }
}
