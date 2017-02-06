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
    }
}
