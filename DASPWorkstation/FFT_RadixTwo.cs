using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DASPWorkstation
{
    public class FFT_RadixTwo
    {
        private List<Complex> X = new List<Complex>();

        public List<Complex> PerformRadixTwoFFT(List<float> signal, int N)
        {
            var BR_Index = BitReversal(N);
            var signalBR = BitReverseSignal(BR_Index, signal);
            var X_FirstStage = FirstStage(signalBR);
            X = LastStages(X_FirstStage);

            var FT_DEBUG_LIST = new List<string>();

            for (int n = 0; n < N; n++)
            {
                FT_DEBUG_LIST.Add($"Bin {n}, {X[n].Real}, {X[n].Imaginary}");
            }

            File.WriteAllLines("DEBUG DFT or FFT output.txt", FT_DEBUG_LIST);

            return X;
        }


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


        public List<float> BitReverseSignal(List<int> BR_Index, List<float> signal)
        {
            var signalBR = new List<float>();

            for (int n = 0; n < BR_Index.Count; n++)
            {
                signalBR.Add(signal[BR_Index[n]]);
            }

            return signalBR;
        }


        public List<float> FirstStage(List<float> signalBR)
        {
            var X_FirstStage = new List<float>(new float[signalBR.Count]);
            float even;
            float odd;

            for (int n = 0; n < signalBR.Count / 2; n++)
            {
                even = signalBR[n * 2];
                odd = signalBR[n * 2 + 1];
                X_FirstStage[n * 2] = even + odd;
                X_FirstStage[n * 2 + 1] = even + (odd * -1);
            }

            return X_FirstStage;
        }


        public List<Complex> LastStages(List<float> X_FirstStage)
        {
            var ftHelper = new FT_Helper();
            var Wdivide = 4;
            var N = X_FirstStage.Count;
            var DFTnum = N / 2;
            X = new List<Complex>();

            for (int m = 0; m < N; m++)
            {
                X.Add(new Complex(X_FirstStage[m], 0));
            }

            for (int stage = 2; stage <= Math.Log(N) / Math.Log(2); stage++) // loop for each stage of fft 
            {
                var m = 0;
                for (int i = 0; i < DFTnum / 2; i++) // loop for each DFT in each stage 
                {
                    for (int n = 0; n < Wdivide / 2; n++) // loop to seperate + and - indexes 
                    {
                        Complex FH = ftHelper.ComplexMultiplication(new Complex(X[(Wdivide / 2) + m].Real, X[(Wdivide / 2) + m].Imaginary), new Complex((((float)Math.Cos((2 * Math.PI * n) / Wdivide))), (-1 * ((float)Math.Sin((2 * Math.PI * n) / Wdivide)))));
                        FH.Real = FH.Real + X[m].Real;
                        FH.Imaginary = FH.Imaginary + X[m].Imaginary;

                        Complex SH = ftHelper.ComplexMultiplication(new Complex(X[m + (Wdivide / 2)].Real, X[(Wdivide / 2) + m].Imaginary), new Complex(((float)Math.Cos((2 * Math.PI * (n + (Wdivide / 2))) / Wdivide)), (-1 * ((float)Math.Sin(2 * Math.PI * ((Wdivide / 2) + m) / Wdivide)))));
                        SH.Real = SH.Real + X[m].Real;
                        SH.Imaginary = SH.Imaginary + X[m].Imaginary;

                        X[m].Real = FH.Real;
                        X[m].Imaginary = FH.Imaginary;
                        X[(Wdivide / 2) + m].Real = SH.Real;
                        X[(Wdivide / 2) + m].Imaginary = SH.Imaginary;

                        m++;
                    }
                    m = m + (Wdivide / 2);
                }
                Wdivide = Wdivide * 2;
                DFTnum = DFTnum / 2;
            }

            return X;
        }
    }
}



//                        //**************<Second+ Stages>******************

