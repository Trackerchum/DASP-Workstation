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


        public Complex ComplexMultiplication(Complex complex1, Complex complex2)
        {
            Complex complexMult = new Complex(0, 0);

            complexMult.Real = complexMult.Real + (complex1.Real * complex2.Real);
            complexMult.Imaginary = complexMult.Imaginary + (complex1.Real * complex2.Imaginary);
            complexMult.Imaginary = complexMult.Imaginary + (complex1.Imaginary * complex2.Real);
            complexMult.Real = complexMult.Real + ((complex1.Imaginary * complex2.Imaginary) * -1);

            return complexMult;
        }


        public List<float> ConvertToDB(List<float> Xmag, int N)
        {
            var XmagDB = new List<float>(new float[N]);
            for (int m = 0; m < N; m++)
            {
                XmagDB[m] = 20 * (float)Math.Log10(Xmag[m] / (N / 2.0f));
            }

            return XmagDB;
        }


        // TODO: prep db for scale - positive


        public void DEBUG_PrintFT_TextFile(List<float> Xmag, int N, int samplingRate)
        {
            var FT_DEBUG_LIST = new List<string>();

            for (int n = 0; n < N/2+1; n++)
            {
                FT_DEBUG_LIST.Add($"Bin {n}, {(samplingRate/(float)N) * n}Hz --- {Xmag[n]}");
            }

            File.WriteAllLines("DEBUG DFT or FFT output.txt", FT_DEBUG_LIST);
        }
    }
}
