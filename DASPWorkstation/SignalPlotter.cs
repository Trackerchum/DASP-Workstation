using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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

        public Image GenerateImage(List<int> scaledSignal)
        {
            WriteableBitmap signalBmp = BitmapFactory.New(1270, 202);
            Image waveform = new Image();

           
            using (signalBmp.GetBitmapContext())
            {
                for (int n = 1; n < 1270 - 1; n++)
                {
                    signalBmp.DrawLine(n, scaledSignal[n], n + 1, scaledSignal[n + 1], Colors.Black);
                }
            }
            waveform.Source = signalBmp;

            return waveform;
        }
    }
}
