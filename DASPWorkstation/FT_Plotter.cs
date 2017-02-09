using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DASPWorkstation
{
    public class FT_Plotter
    {
        List <int> scaledFT = new List<int>();

        public List<int> ScaleFT(List<float> ft, int N) 
        {
            scaledFT = new List<int>(new int[1270]);

            if (ft.Count > 2540)
            {
                var range = (int)((N / 2) / 1270);

                for (int n = 0; n < 1270; n++) // maxes out around 22825Hz for 48kHz fs, 8k res
                {

                    var _n = (int)(((N / 2) / 1270) * n); // loop here to pick out highest value in range 


                    scaledFT[n] = (((int)((ft[_n] / ft.Max()) * 200)) - 200) * -1;
                }
            }
            else
            {
                //for (int n = 0; n < scaledFT.Count / 2; n++) // edit for under 1270
                //{
                //    scaledFT[n] = (((int)((ft[n] / ft.Max()) * 200)) - 200) * -1;
                //}
            }

            return scaledFT;
        }
    }
}
