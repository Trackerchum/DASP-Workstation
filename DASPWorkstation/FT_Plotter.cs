using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DASPWorkstation
{
    public class FT_Plotter
    {
        
        private int canvasWidth = 1270;
        private int canvasLength = 200;

        List <int> scaledFT = new List<int>();

        public List<int> ScaleFT(List<float> ft, int N) 
        {
            scaledFT = new List<int>(new int[canvasWidth]);

            if (ft.Count >= canvasWidth*2)
            {
                scaledFT = new List<int>(new int[canvasWidth]);
                float _n;
                var range = Math.Ceiling((((float)N / 2) / (canvasWidth - 1)));

                for (int n = 0; n < canvasWidth; n++)
                {
                    _n = 0;

                    for (int l = 0; l < range; l++)
                    {
                        if (ft[(int)((((float)N / 2) / (canvasWidth-1)) * n) + l] > _n)
                        {
                            _n = ft[(int)((((float)N / 2) / (canvasWidth - 1)) * n) + l];
                        }
                    }

                    scaledFT[n] = (((int)((_n / ft.Max()) * canvasLength)) - canvasLength) * -1;
                }
            }
            else
            {
                scaledFT = new List<int>(new int[N/2+1]);

                for (int n = 0; n <= N / 2; n++)
                {
                    scaledFT[n] = (((int)((ft[n] / ft.Max()) * canvasLength)) - canvasLength) * -1;
                }
            }

            return scaledFT;
        }
    }
}
