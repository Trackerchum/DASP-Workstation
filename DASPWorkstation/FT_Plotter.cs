using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DASPWorkstation
{
    public class FT_Plotter
    {

        private int canvasWidth = 1270;
        private int canvasLength = 200;

        public List<int> scaledFT = new List<int>();


        public List<float> PrepDB(List<float> XmagDB)
        {
            var preppedDB = new List<float>();
            var MinValue = XmagDB.Min() * -1;

            for (int m = 0; m < XmagDB.Count; m++)
            {
                preppedDB.Add(XmagDB[m] + MinValue);
            }

            return preppedDB;
        }


        public List<int> ScaleFT(List<float> ft, int N)
        {
            scaledFT = new List<int>(new int[canvasWidth]);

            if (ft.Count >= canvasWidth * 2)
            {
                scaledFT = new List<int>(new int[canvasWidth]);
                float _n;
                var range = Math.Ceiling((((float)N / 2) / (canvasWidth - 1)));

                for (int n = 0; n < canvasWidth; n++)
                {
                    _n = 0;

                    for (int l = 0; l < range; l++)
                    {
                        if (ft[(int)((((float)N / 2) / (canvasWidth - 1)) * n) + l] > _n)
                        {
                            _n = ft[(int)((((float)N / 2) / (canvasWidth - 1)) * n) + l];
                        }
                    }

                    scaledFT[n] = (((int)((_n / ft.Max()) * canvasLength)) - canvasLength) * -1;
                }
            }
            else
            {
                scaledFT = new List<int>(new int[N / 2 + 1]);

                for (int n = 0; n <= N / 2; n++)
                {
                    scaledFT[n] = (((int)((ft[n] / ft.Max()) * canvasLength)) - canvasLength) * -1;
                }
            }

            return scaledFT;
        }

        public Image GenerateImage(List<int> scaledFT, int resolution)
        {
            WriteableBitmap ftBmp = BitmapFactory.New(1270, 202);
            Image ftImage = new Image();

            using (ftBmp.GetBitmapContext())
            {
                if (resolution >= 2540)
                {
                    for (int n = 0; n < 1270 - 1; n++)
                    {
                        ftBmp.DrawLine(n, scaledFT[n], n + 1, scaledFT[n + 1], Colors.Black);
                    }
                }
                else
                {
                    for (int n = 0; n < scaledFT.Count - 1; n++)
                    {
                        ftBmp.DrawLine((int)((1269.0f / (scaledFT.Count - 1)) * n), scaledFT[n], (int)((1269.0f / (scaledFT.Count - 1)) * ((float)n + 1)), scaledFT[n + 1], Colors.Black);
                    }
                }
            }
            ftImage.Source = ftBmp;
            return ftImage;
        }
    }
}
