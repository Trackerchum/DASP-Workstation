using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DASPWorkstation
{
    public class FT_Plotter
    {
        public List<int> ScaleFT(List<float> ft, int N)
        {
            var scaledFT = new List<int>();

            if (N < 1270)
            {
                scaledFT = new List<int>(new int[N]);
                for (int n = 0; n < scaledFT.Count; n++)
                {
                    //draw line 
                    scaledFT[n] = (int)((ft[n] / ft.Max()) * 200);
                }
            }
            else
            {
                scaledFT = new List<int>(new int[1270]);
                for (int n = 0; n < scaledFT.Count; n++)
                {
                    scaledFT[n] = (int)((ft[n] / ft.Max()) * 200);
                }
            }

            
            return scaledFT;
        }
    }
}
