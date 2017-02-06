using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DASPWorkstation.Test
{
    public class Z_SpecHelper
    {
        public bool AreApproximatelyEqual(float actual, float expected)
        {
            if ((Math.Sqrt((actual - expected) * (actual - expected))) > 0.001)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
