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

        public int N;

        public List<Complex> PerformDFT(List<float> signal)
        {
            X = new List<Complex>();

            for (int m = 0; m < N; m++)
            {
                X.Add(new Complex(0, 0));
                for (int n = 0; n < N; n++)
                {
                    Complex placeholder = new Complex((signal[n] * ((float)Math.Cos((2 * Math.PI * n * m) / N))), (signal[n] * ((float)-Math.Sin((2 * Math.PI * n * m) / N))));
                    X[m].Real = X[m].Real + placeholder.Real;
                    X[m].Imaginary = X[m].Imaginary + placeholder.Imaginary;
                }
            }
            return X;
        }
    }
}
