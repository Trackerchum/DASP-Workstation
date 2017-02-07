using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DASPWorkstation
{
    public class FT_Helper
    {
        public float Abs(Complex complex)
        {
            float complexAbs = (float)Math.Sqrt((complex.Real * complex.Real) + (complex.Imaginary * complex.Imaginary));
            return complexAbs;
        }

        public List<float> ConvertToDB(List<float> Xmag, int N)
        {
            var XmagDB = new List<float>(new float[N]);
            for (int m = 0; m < N; m++)
            {
                XmagDB[m] = 20 * (float)Math.Log10(Xmag[m] / (N / 2));
            }

            return XmagDB;
        }
    }
}
