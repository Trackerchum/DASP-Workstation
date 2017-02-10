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
                float _n;
                var range = Math.Ceiling((float)((N / 2) / 1270));

                for (int n = 0; n < 1270; n++) // 48kHz - maxes out around 22825Hz 8k res, 17400Hz 7k res, 20275Hz 6k res, 12100Hz 5k res, 15216Hz 4k res, 20289Hz 3k res
                {
                    _n = 0;

                    for (int l = 0; l < range; l++)
                    {
                        if (ft[(int)(((N / 2) / 1270) * range) + l] > _n)
                        {
                            _n = ft[(int)(((N / 2) / 1270) * n)];
                        }
                    }


                    scaledFT[n] = (((int)((_n / ft.Max()) * 200)) - 200) * -1;
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
