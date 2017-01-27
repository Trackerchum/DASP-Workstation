using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DASP_WorkstationWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        private SignalGenerator signalGenerator;

        public MainWindow()
        {
            InitializeComponent();
            fillPresetSignalsComboBox();
            signalGenerator = new SignalGenerator();
        }

        private void plotSignalBtn_Click(object sender, RoutedEventArgs e)
        {
            validateSignalUserInput();
            extractSignalValues();
            clearSignal();
            generateSignal();
            plotSignal();
        }

        void extractSignalValues()
        {
            TextBox txtAmplitude;
            TextBox txtFrequency;
            TextBox txtPhase;

            for (int n = 0; n <= 9; n++)
            {
                txtAmplitude = (TextBox)FindName("amplitude" + n);
                txtFrequency = (TextBox)FindName("frequency" + n);
                txtPhase = (TextBox)FindName("phase" + n);

                if (txtAmplitude.Text != "" && txtFrequency.Text != "" && txtPhase.Text != "")
                {
                    signalGenerator.AddSignalValue(float.Parse(txtAmplitude.Text), float.Parse(txtFrequency.Text), float.Parse(txtPhase.Text));
                }
            }
        }


        void fillPresetSignalsComboBox()
        {

        }
        

        void validateSignalUserInput()
        {

        }

        void generateSignal()
        {
            
        }


        void plotSignal()
        {
            WriteableBitmap writeableBmp = BitmapFactory.New(1270, 202);
            Image waveform = new Image();
            int y;

            using (writeableBmp.GetBitmapContext())
            {
                for (int n = 1; n < 1270; n++)
                {
                    y = signalGenerator.ScaleSignal(n);
                    writeableBmp.SetPixel(n, y + 1, Colors.Black);
                }

                waveform.Source = writeableBmp;
            }
            signalCanvas.Children.Clear();
            signalCanvas.Children.Add(waveform);
        }


        private void samplingRateCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string samplingRateStr = (samplingRate.SelectedValue as ComboBoxItem).Content.ToString();
            switch (samplingRateStr)
            {
                case "44.1kHz":
                    samplingRate = 44100;
                    break;
                case "48kHz":
                    samplingRate = 48000;
                    break;
                case "96kHz":
                    samplingRate = 96000;
                    break;
                case "192kHz":
                    samplingRate = 192000;
                    break;
                default:
                    break;
            } 
        }


        private void plotDFTBtn_Click(object sender, RoutedEventArgs e)
        {
            validateDFTUserInput();
            extractDFTValues();
            applyDFT();
            extractMagnitude();
            plotDFT();
        }


        void validateDFTUserInput()
        {

        }


        void extractDFTValues()
        {

        }


        void applyDFT()
        {

        }

        void extractMagnitude()
        {

        }

        void plotDFT()
        {

        }
    }
}
