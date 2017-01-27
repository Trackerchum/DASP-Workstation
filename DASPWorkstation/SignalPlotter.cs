using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DASPWorkstation
{
    public class SignalPlotter
    {
        public List<int> ScaleSignal(List<float> signal, int samplingRate)
        {
            var scaledSignal = new List<int>();
            float maxSample;

            if (signal.Max() > Math.Sqrt((signal.Min() * signal.Min())))
            {
                maxSample = signal.Max();
            }
            else
            {
                maxSample = (float)Math.Sqrt((signal.Min() * signal.Min()));
            }

            for (int n = 0; n < 1270; n++)
            {
                scaledSignal.Add((int)(((signal[n] * -1 / maxSample) + 1) * 100));
            }
            return scaledSignal;
        }
    }
}
