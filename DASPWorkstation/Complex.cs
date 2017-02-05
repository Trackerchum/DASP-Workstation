using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DASPWorkstation
{
    public class Complex
    {
        public float Real { get; set; }
        public float Imaginary { get; set; }

        public Complex(float real, float imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }
    }
}
