using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DASPWorkstation
{
    public class DFT
    {
        public List<Complex> PerformDFT(List<float> signal, int resolution)
        {
            var X = new List<Complex>(new float[resolution], new float[resolution]);
            
            
            //for (int m = 0; m < N; m++)
            //{
            //    for (int n = 0; n < N; n++)
            //    {
            //        re = x[n] * ((float)Math.Cos((2 * pi * n * m) / N));
            //        im = x[n] * ((float)Math.Sin((2 * pi * n * m) / N));
            //        Xre[m] = Xre[m] + re;
            //        Xim[m] = Xim[m] + im;
            //    }
            //}

            return X;
        }
    }
}
