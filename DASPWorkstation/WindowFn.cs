using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DASPWorkstation
{
    public class WindowFn
    {
        public List<float> CurrentSignalWn = new List<float>();

        public List<float> ApplyFlatTop(List<float> signal, int N)
        {
            var wnCoefficients = new List<float>(new float[] { 1.0f, -1.93f, 1.29f, -0.388f, 0.028f });
            var SignalWn = ApplyWindow(signal, wnCoefficients, N);
            return SignalWn;
        }


        public List<float> ApplyBlackman(List<float> signal, int N)
        {
            var wnCoefficients = new List<float>(new float[] { 0.42659f, -0.49656f, 0.076849f });
            var SignalWn = ApplyWindow(signal, wnCoefficients, N);
            return SignalWn;
        }


        public List<float> ApplyBlackmanHarris(List<float> signal, int N)
        {
            var wnCoefficients = new List<float>(new float[] { 0.35875f, -0.48829f, 0.14128f, -0.01168f });
            var SignalWn = ApplyWindow(signal, wnCoefficients, N);
            return SignalWn;
        }


        public List<float> ApplyHamming(List<float> signal, int N)
        {
            var wnCoefficients = new List<float>(new float[] { 0.54f, -0.46f });
            var SignalWn = ApplyWindow(signal, wnCoefficients, N);
            return SignalWn;
        }


        public List<float> ApplyNuttall(List<float> signal, int N)
        {
            var wnCoefficients = new List<float>(new float[] { 0.355768f, -0.487396f, 0.144232f, -0.012604f });
            var SignalWn = ApplyWindow(signal, wnCoefficients, N);
            return SignalWn;
        }


        public List<float> ApplyBlackmanNuttall(List<float> signal, int N)
        {
            var wnCoefficients = new List<float>(new float[] { 0.3635819f, -0.4891775f, 0.1365995f, -0.0106411f });
            var SignalWn = ApplyWindow(signal, wnCoefficients, N);
            return SignalWn;
        }

        
        private List<float> ApplyWindow(List<float> signal, List<float> wnCoefficients, int N)
        {
            var SignalWn = new List<float>();
            for (int n = 0; n < N; n++)
            {
                var wn = wnCoefficients[0];
                for (int o = 1; o < wnCoefficients.Count; o++)
                {
                    wn = wn + wnCoefficients[o] * (float)Math.Cos((2 * Math.PI * o * n) / (N - 1));
                }
                SignalWn.Add(wn * signal[n]);
            }
            return SignalWn;
        }
    }
}
