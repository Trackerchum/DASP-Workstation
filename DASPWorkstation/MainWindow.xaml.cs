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

namespace DASPWorkstation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int samplingRate = 48000;
        private SignalHelper _signalHelper = new SignalHelper();
        private SignalGenerator _signalGenerator = new SignalGenerator();
        private Validator _validator = new Validator();
        private FT_Helper _ftHelper = new FT_Helper();

        public MainWindow()
        {
            InitializeComponent();
        }


        private void addSineBtn_Click(object sender, RoutedEventArgs e)
        {
            var statusCode = _validator.ValidateSignalParamters(amplitude.Text, frequency.Text, phase.Text);
            if (statusCode == Validator.ValidatorStatusCode.OK)
            {
                var signalDefinition = new SignalDefinition(float.Parse(amplitude.Text), float.Parse(frequency.Text), float.Parse(phase.Text));
                _signalHelper.AddSine(signalDefinition);
                sineWavesCmb.Items.Add(signalDefinition.ToString(float.Parse(amplitude.Text), float.Parse(frequency.Text), float.Parse(phase.Text)));
                amplitude.Text = ""; frequency.Text = ""; phase.Text = "";
                samplingRateCmb.IsEnabled = false;
            }
            else
            {
                MessageBox.Show($"Unable to add sine wave, function exited with error code; \n\n {statusCode}", "Error");
            }
        }


        private void plotSignalBtn_Click(object sender, RoutedEventArgs e)
        {
            var sineCount = _signalHelper.GetValues();
            if (sineCount.Count != 0)
            {
                var signalPlotter = new SignalPlotter();
                WriteableBitmap signalBmp = BitmapFactory.New(1270, 202);
                Image waveform = new Image();

                var signal = _signalGenerator.GenerateSignal(_signalHelper.GetValues(), samplingRate);
                var scaledSignal = signalPlotter.ScaleSignal(signal, samplingRate);
                using (signalBmp.GetBitmapContext())
                {
                    for (int n = 1; n < 1270; n++)
                    {
                        signalBmp.SetPixel(n, scaledSignal[n] + 1, Colors.Black);
                    }
                }
                waveform.Source = signalBmp;

                signalCanvas.Children.Clear();
                signalCanvas.Children.Add(waveform);
            }
            else
            {
                MessageBox.Show("Unable to plot signal, no sine waves have been added.", "Error");
            }
        }


        private void clearSignalBtn_Click(object sender, RoutedEventArgs e)
        {
            _signalHelper.ClearValues();
            sineWavesCmb.Items.Clear();
            samplingRateCmb.IsEnabled = true;
            sineWavesCmb.IsEnabled = true;
            signalCanvas.Children.Clear();
        }


        private void editSineBtn_Click(object sender, RoutedEventArgs e)
        {
            if (sineWavesCmb.SelectedIndex != -1)
            {
                if ((string)editSineBtn.Content == "Edit Sine Wave")
                {
                    var signal = _signalHelper.GetValues();
                    amplitude.Text = signal[sineWavesCmb.SelectedIndex].Amplitude.ToString();
                    frequency.Text = signal[sineWavesCmb.SelectedIndex].Frequency.ToString();
                    phase.Text = signal[sineWavesCmb.SelectedIndex].Phase.ToString();
                    sineWavesCmb.IsEnabled = false;
                    addSineBtn.IsEnabled = false;
                    editSineBtn.Content = "Save Sine Wave";
                }
                else
                {
                    var statusCode = _validator.ValidateSignalParamters(amplitude.Text, frequency.Text, phase.Text);
                    if (statusCode == Validator.ValidatorStatusCode.OK)
                    {
                        var n = sineWavesCmb.SelectedIndex;
                        sineWavesCmb.IsEnabled = true;
                        addSineBtn.IsEnabled = true;
                        var signalDefinition = new SignalDefinition(float.Parse(amplitude.Text), float.Parse(frequency.Text), float.Parse(phase.Text));
                        sineWavesCmb.Items[n] = signalDefinition.ToString(float.Parse(amplitude.Text), float.Parse(frequency.Text), float.Parse(phase.Text));
                        amplitude.Text = ""; frequency.Text = ""; phase.Text = "";
                        _signalHelper.UpdateValues(signalDefinition, n);
                        editSineBtn.Content = "Edit Sine Wave";
                    }
                    else
                    {
                        MessageBox.Show($"Unable to add save sine wave, function exited with error code; \n\n {statusCode}", "Error");
                    }
                }
            }
            else
            {
                MessageBox.Show("No sine wave selected for edit", "Error");
            }
        }


        private void samplingRateCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch ((samplingRateCmb.SelectedValue as ComboBoxItem).Content.ToString())
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
            if (_signalGenerator.currentSignal.Count != 0)
            {
                var statusCode = _validator.ValidateDFTResolution(resolutionTxt.Text);
                if (statusCode == Validator.ValidatorStatusCode.OK)
                {
                    var dft = new DFT();
                    var X = dft.PerformDFT(_signalGenerator.currentSignal, int.Parse(resolutionTxt.Text));
                    var Xmag = new List<float>(new float[int.Parse(resolutionTxt.Text)]);
                    for (int m = 0; m < int.Parse(resolutionTxt.Text); m++)
                    {
                        Xmag[m] = _ftHelper.Abs(X[m]);
                    }

                    _ftHelper.DEBUG_PrintFT_TextFile(Xmag, int.Parse(resolutionTxt.Text), samplingRate);

                    if ((string)LinDBswitchBtn.Content == "Logarithmic (dB)")
                    {
                        plotFT(Xmag);
                    }
                    else
                    {
                        var XmagDB = _ftHelper.ConvertToDB(Xmag, int.Parse(resolutionTxt.Text));
                        plotFT(XmagDB);
                    }
                }
                else
                {
                    MessageBox.Show($"Unable to plot DFT, function exited with error code; \n\n {statusCode}", "Error");
                }
            }
            else
            {
                MessageBox.Show("Signal must be ploted before DFT can be performed", "Error");
            }
        }


        private void LinDBswitchBtn_Click(object sender, RoutedEventArgs e)
        {
            if ((string)LinDBswitchBtn.Content == "Logarithmic (dB)")
            {
                LinDBswitchBtn.Content = "Linear";
            }
            else
            {
                LinDBswitchBtn.Content = "Logarithmic (dB)";
            }
        }


        public void plotFT(List <float> FT) 
        {
            var ftPlotter = new FT_Plotter();
            WriteableBitmap ftBmp = BitmapFactory.New(1270, 202);
            Image ftImage = new Image();
            var scaledFT = ftPlotter.ScaleFT(FT, int.Parse(resolutionTxt.Text));
            
            using (ftBmp.GetBitmapContext())
            {
                if (int.Parse(resolutionTxt.Text) >= 2540)
                {
                    for (int n = 0; n < 1270-1; n++)
                    {
                        ftBmp.DrawLine(n, scaledFT[n], n+1, scaledFT[n+1], Colors.Black);
                    }
                }
                else
                {
                    for (int n = 0; n < scaledFT.Count-1; n++)
                    {
                        ftBmp.DrawLine((int)((1270.0f / scaledFT.Count)*n), scaledFT[n], (int)((1270.0f / scaledFT.Count) * (float)(n+1)), scaledFT[n + 1], Colors.Black);
                    }
                }
            }
            ftImage.Source = ftBmp;

            fourierCanvas.Children.Clear();
            fourierCanvas.Children.Add(ftImage);
        }


        private void sineWavesCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        private void windowCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
