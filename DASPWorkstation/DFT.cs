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

        public List<Complex> PerformDFT(List<float> signal, int N)
        {
            X = new List<Complex>(N);

            for (int m = 0; m < N; m++)
            {
                for (int n = 0; n < N; n++)
                {
                    Complex placeholder = new Complex((signal[n] * ((float)Math.Cos((2 * Math.PI * n * m) / N))), (signal[n] * ((float)Math.Sin((2 * Math.PI * n * m) / N))));
                    X[m] = X[m] + placeholder;
                }
            }

            return X;
        }
    }
}
