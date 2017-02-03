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
        public List<float> currentSignal = new List<float>();

        public List<float> GenerateSignal(List<SignalDefinition> signalParameters, int samplingRate)
        {
            currentSignal = new List<float>(new float[samplingRate]);
            
            for (int x = 0; x < signalParameters.Count; x++)
            {
                for (int n = 0; n < samplingRate; n++)
                {
                    currentSignal[n] = currentSignal[n] + (signalParameters[x].Amplitude * (float)(Math.Sin(2 * Math.PI * n * signalParameters[x].Frequency / samplingRate + (signalParameters[x].Phase * (Math.PI / 180)))));
                }
            }
            return currentSignal;
        }
    }


    public interface ISignalGenerator
    {
        List<float> GenerateSignal(List<SignalDefinition> signalParameters, int samplingRate);
    }
}
