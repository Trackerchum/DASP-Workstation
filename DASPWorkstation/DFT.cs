using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DASPWorkstation
{
    public class DFT
    {
        private List<Complex> X = new List<Complex>();

        public List<Complex> PerformDFT(List<float> signal, int resolution)
        {
            X = new List<Complex>(new float[resolution], new float[resolution]);
            X.Add(new Complex(1, 1));
            

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
