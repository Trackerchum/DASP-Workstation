using System;
using System.Collections.Generic;
using System.IO;
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


        public void DEBUG_PrintFT_TextFile(List<float> Xmag, int N, int samplingRate)
        {
            var FT_DEBUG_LIST = new List<string>();

            for (int n = 0; n < N/2+1; n++)
            {
                FT_DEBUG_LIST.Add($"Bin {n}, {(samplingRate/N) * n}Hz --- {Xmag[n]}");
            }

            File.WriteAllLines("DEBUG DFT or FFT output.txt", FT_DEBUG_LIST);
        }
    }
}
