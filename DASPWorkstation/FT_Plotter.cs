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

            if (ft.Count >= 2540)
            {
                scaledFT = new List<int>(new int[1270]);
                float _n;
                var range = Math.Ceiling((((float)N / 2) / (float)1269));

                for (int n = 0; n < 1270; n++)
                {
                    _n = 0;

                    for (int l = 0; l < range; l++)
                    {
                        if (ft[(int)((((float)N / 2) / (float)1269) * n) + l] > _n)
                        {
                            _n = ft[(int)((((float)N / 2) / (float)1269) * n) + l];
                        }
                    }

                    scaledFT[n] = (((int)((_n / ft.Max()) * 200)) - 200) * -1;
                }
            }
            else
            {
                scaledFT = new List<int>(new int[N]);

                for (int n = 0; n < N / 2; n++)
                {
                    scaledFT[n] = (((int)((ft[n] / ft.Max()) * 200)) - 200) * -1;
                }
            }

            return scaledFT;
        }
    }
}
