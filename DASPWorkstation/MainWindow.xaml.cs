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

        public MainWindow()
        {
            InitializeComponent();
        }


        private void addSineBtn_Click(object sender, RoutedEventArgs e)
        {
            var validator = new Validator();
            var statusCode = validator.Validate(amplitude.Text, frequency.Text, phase.Text);
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


        private void clearSignalBtn_Click(object sender, RoutedEventArgs e)
        {
            // _signalGenerator.BlankSignal(samplingRate);
            _signalHelper.ClearValues();
            sineWavesCmb.Items.Clear();
            samplingRateCmb.IsEnabled = true;
            sineWavesCmb.IsEnabled = true;
            signalCanvas.Children.Clear();
        }


        private void editSineBtn_Click(object sender, RoutedEventArgs e)
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
                var n = sineWavesCmb.SelectedIndex;
                sineWavesCmb.IsEnabled = true;
                addSineBtn.IsEnabled = true;
                editSineBtn.Content = "Edit Sine Wave";
                var signalDefinition = new SignalDefinition(float.Parse(amplitude.Text), float.Parse(frequency.Text), float.Parse(phase.Text)); 
                sineWavesCmb.Items[n] = signalDefinition.ToString(float.Parse(amplitude.Text), float.Parse(frequency.Text), float.Parse(phase.Text));
                amplitude.Text = ""; frequency.Text = ""; phase.Text = "";
                _signalHelper.UpdateValues(signalDefinition, n);
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


        private void sineWavesCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
