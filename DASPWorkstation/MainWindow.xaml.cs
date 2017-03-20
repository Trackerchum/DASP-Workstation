using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DASPWorkstation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int samplingRate = 48000;
        int resolution;
        bool DFT_FFT;

        private SignalHelper _signalHelper = new SignalHelper();
        private SignalGenerator _signalGenerator = new SignalGenerator();
        private Validator _validator = new Validator();
        private FT_Helper _ftHelper = new FT_Helper();
        private FT_Plotter ftPlotter = new FT_Plotter();
        private DFT dft = new DFT();
        private FFT_RadixTwo radix2FFT = new FFT_RadixTwo();

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
                Image waveform = new Image();

                var signal = _signalGenerator.GenerateSignal(_signalHelper.GetValues(), samplingRate);
                var scaledSignal = signalPlotter.ScaleSignal(signal, samplingRate);

                waveform = signalPlotter.GenerateImage(scaledSignal);

                signalCanvas.Children.Clear();
                signalCanvas.Children.Add(waveform);

                maxSigLbl.Content = Math.Round((decimal)signal.Max(), 4);
                minSigLbl.Content = Math.Round((-1 * (decimal)signal.Max()), 4);

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

            PlotFTFreqLabels();
        }


        private void plotDFTBtn_Click(object sender, RoutedEventArgs e)
        {
            if (_signalGenerator.currentSignal.Count != 0)
            {
                var statusCode = _validator.ValidateDFTResolution(resolutionTxt.Text);
                if (statusCode == Validator.ValidatorStatusCode.OK)
                {
                    DFT_FFT = false;
                    windowCmb.IsEnabled = true;
                    resolution = int.Parse(resolutionTxt.Text);
                    var X = dft.PerformDFT(_signalGenerator.currentSignal, resolution);
                    var Xmag = new List<float>();
                    for (int m = 0; m < resolution; m++)
                    {
                        Xmag.Add(_ftHelper.Abs(X[m]));
                    }

                    // _ftHelper.DEBUG_PrintFT_TextFile(Xmag, resolution, samplingRate);

                    if ((string)LinDBswitchBtn.Content == "Logarithmic (dB)")
                    {
                        plotFT(Xmag);
                        PlotFTLabels(Xmag);
                    }
                    else
                    {
                        var XmagDB = _ftHelper.ConvertToDB(Xmag, resolution);
                        var preppedDB = ftPlotter.PrepDB(XmagDB);
                        plotFT(preppedDB);
                        PlotFTLabels(XmagDB);
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


        private void plotFFTBtn_Click(object sender, RoutedEventArgs e)
        {
            if (_signalGenerator.currentSignal.Count != 0)
            {
                DFT_FFT = true;
                resolution = Convert.ToInt32((FFT_ResCmb.SelectedValue as ComboBoxItem).Content);
                var X = radix2FFT.PerformRadixTwoFFT(_signalGenerator.currentSignal, resolution);
                var Xmag = new List<float>();
                for (int m = 0; m < resolution; m++)
                {
                    Xmag.Add(_ftHelper.Abs(X[m]));
                }

                // _ftHelper.DEBUG_PrintFT_TextFile(Xmag, resolution, samplingRate);

                if ((string)LinDBswitchBtn.Content == "Logarithmic (dB)")
                {
                    plotFT(Xmag);
                    PlotFTLabels(Xmag);
                }
                else
                {
                    var XmagDB = _ftHelper.ConvertToDB(Xmag, resolution);
                    var preppedDB = ftPlotter.PrepDB(XmagDB);
                    plotFT(preppedDB);
                    PlotFTLabels(XmagDB);
                }
            }
            else
            {
                MessageBox.Show("Signal must be ploted before FFT can be performed", "Error");
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


        public void plotFT(List<float> FT)
        {
            //WriteableBitmap ftBmp = BitmapFactory.New(1270, 202);
            Image ftImage = new Image();
            var scaledFT = ftPlotter.ScaleFT(FT, resolution);

            ftImage = ftPlotter.GenerateImage(scaledFT, resolution);

            fourierCanvas.Children.Clear();
            fourierCanvas.Children.Add(ftImage);
        }


        private void applyWindowBtn_Click(object sender, RoutedEventArgs e)
        {
            if (_signalGenerator.currentSignal.Count != 0 || ftPlotter.scaledFT.Count != 0)
            {
                var _windowFn = new WindowFn();

                switch (windowCmb.SelectedIndex)
                {
                    case 0:
                        _windowFn.CurrentSignalWn = _signalGenerator.currentSignal; // Rectangular
                        break;
                    case 1:
                        _windowFn.CurrentSignalWn = _windowFn.ApplyFlatTop(_signalGenerator.currentSignal, resolution); // Flat Top
                        break;
                    case 2:
                        _windowFn.CurrentSignalWn = _windowFn.ApplyBlackman(_signalGenerator.currentSignal, resolution); // Blackman
                        break;
                    case 3:
                        _windowFn.CurrentSignalWn = _windowFn.ApplyBlackmanHarris(_signalGenerator.currentSignal, resolution); // Blackman–Harris
                        break;
                    case 4:
                        _windowFn.CurrentSignalWn = _windowFn.ApplyHamming(_signalGenerator.currentSignal, resolution); // Hamming
                        break;
                    case 5:
                        _windowFn.CurrentSignalWn = _windowFn.ApplyNuttall(_signalGenerator.currentSignal, resolution); // Nuttall
                        break;
                    case 6:
                        _windowFn.CurrentSignalWn = _windowFn.ApplyBlackmanNuttall(_signalGenerator.currentSignal, resolution); // Blackman–Nuttall
                        break;
                    default:
                        break;
                }

                List<Complex> X = new List<Complex>();

                if (DFT_FFT == false)
                {
                    X = dft.PerformDFT(_windowFn.CurrentSignalWn, resolution);
                }
                else
                {
                    X = radix2FFT.PerformRadixTwoFFT(_windowFn.CurrentSignalWn, resolution);
                }

                var Xmag = new List<float>();
                for (int m = 0; m < resolution; m++)
                {
                    Xmag.Add(_ftHelper.Abs(X[m]));
                }

                // _ftHelper.DEBUG_PrintFT_TextFile(Xmag, resolution, samplingRate);

                if ((string)LinDBswitchBtn.Content == "Logarithmic (dB)")
                {
                    plotFT(Xmag);
                    PlotFTLabels(Xmag);
                }
                else
                {
                    var XmagDB = _ftHelper.ConvertToDB(Xmag, resolution);
                    var preppedDB = ftPlotter.PrepDB(XmagDB);
                    plotFT(preppedDB);
                    PlotFTLabels(XmagDB);
                }
            }
            else
            {
                MessageBox.Show("Signal must be plotted and Fourier transform performed before Window can be applied", "Error");
            }


        }


        private void PlotFTLabels(List<float> FT)
        {
            var quart = Math.Sqrt((FT.Max() - FT.Min()) * (FT.Max() - FT.Min())) / 4;

            var min = FT.Min();
            var max = FT.Max();

            maxFtLbl.Content = Math.Round((decimal)FT.Max(), 2);
            upperFtLbl.Content = Math.Round((decimal)(FT.Max() - quart), 2);
            midFtLbl.Content = Math.Round((decimal)(FT.Max() - (quart * 2)), 2);
            lowerFtLbl.Content = Math.Round((decimal)(FT.Max() - (quart * 3)), 2);
            minFtLbl.Content = Math.Round((decimal)FT.Min(), 2);
        }


        private void PlotFTFreqLabels()
        {
            Label lbl = new Label();

            for (int n = 1; n <= 12; n++)
            {
                lbl = (Label)FindName($"f{n}");
                lbl.Content = $"{(samplingRate / 2.0f / 12) * n}kHz";
            }
        }
    }
}