using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DASP_WorkstationWPF
{
    public class SignalGenerator
    {
        List<float> lstAmplitude = new List<float>();
        List<float> lstFrequency = new List<float>();
        List<float> lstPhase = new List<float>();
        List<float> lstSignal = new List<float>();
        int sineCount;
        public int samplingRate = 48000;
        float maxSample;

        public SignalGenerator()
        {
            sineCount = 0;
        }

        void ClearSignal()
        {
            lstSignal.Clear();
            sineCount = 0;
        }

        public void AddSignalValue(float amplitude, float frequency, float phase)
        {
            lstAmplitude.Add(amplitude);
            lstFrequency.Add(frequency);
            lstPhase.Add(phase * (float)Math.PI / 180);
            sineCount++;                
        }

        void GenerateSignal()
        {
            for (int sine = 0; sine < sineCount; sine++)
            {
                for (int n = 0; n < this.samplingRate; n++)
                {
                    lstSignal[n] = lstSignal[n] + (lstAmplitude[sine] * (float)Math.Sin(2 * Math.PI * n * lstFrequency[sine] / samplingRate + lstPhase[sine]));
                }
            }
        }

        void GetMaxValue()
        {
            if (lstSignal.Max() > (lstSignal.Min() * -1))
            {
                maxSample = lstSignal.Max();
            }
            else
            {
                maxSample = lstSignal.Min() * -1;
            }
        }

        public int ScaleSignal(int )
        {
            return 0;
        }
    }
}
