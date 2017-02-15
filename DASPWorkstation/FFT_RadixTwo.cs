using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DASPWorkstation
{
    public class FFT_RadixTwo
    {
        public List<int> BitReversal(int N)
        {
            var BR_Index = new List<int>(new int[N]);
            BR_Index[0] = 0;
            BR_Index[1] = 1;
            int BR = 1;

            for (int stage = 1; stage < Math.Log(N) / Math.Log(2); stage++)
            {
                BR = BR * 2;
                for (int n = 0; n < BR; n++)
                {
                    BR_Index[n] = 2 * BR_Index[n];
                    BR_Index[n + BR] = BR_Index[n] + 1;
                }
            }

            return BR_Index;
        }

    }
}


//                        for (int n = 0; n<N; n++)
//                        {
//                            BR = BRar[n];
//                            BRx[n] = x[BR];
//                        }

//                        //**************</Bit Reversal>*******************


//                        //**************<First Stage>*********************
//                        for (int n = 0; n<N / 2; n++)
//                        {
//                            even = BRx[n * 2];
//                            odd = BRx[n * 2 + 1];
//                            Xre[n * 2] = even + odd;
//                            Xre[n * 2 + 1] = even + (odd* -1);
//                        }
//                        //**************</First Stage>********************


//                        //**************<Second+ Stages>******************

//                        Wdivide = 4;
//                        DFTnum = N / 2;
//                        m = 0;

//                        for (int stage = 2; stage <= Math.Log(N) / Math.Log(2); stage++) // loop for each stage of fft 
//                        {
//                            m = 0;
//                            for (int i = 0; i<DFTnum / 2; i++) // loop for each DFT in each stage 
//                            {
//                                for (int n = 0; n<Wdivide / 2; n++) // loop to seperate + and - indexes 
//                                {
//                                    reFH = Xre[m] + ((Xre[(Wdivide / 2) + m]) * (((float)Math.Cos(2 * pi * n) / Wdivide)));
//                                    imFH = Xim[m] + ((Xim[Wdivide / 2 + m]) * (-1*((float)Math.Sin(2* pi* n/Wdivide))));

//                                    reSH = (Xre[m + (Wdivide / 2)] * (((float)Math.Cos(2 * pi * (n + (Wdivide / 2))) / Wdivide))) + Xre[m];
//                                    imSH = (Xim[Wdivide / 2 + m] * ((-1*((float)Math.Sin(2* pi*(Wdivide/2+m)/Wdivide))))) + Xim[m];  

//                                    Xre[m] = reFH;
//                                    Xim[m] = imFH;
//                                    Xre[(Wdivide / 2) + m] = reSH;
//                                    Xim[Wdivide / 2 + m] = imSH;
//                                    m++;
//                                }
//                                m = m + (Wdivide / 2);
//                            }
//                            Wdivide = Wdivide* 2;
//                            DFTnum = DFTnum / 2;
//                        }