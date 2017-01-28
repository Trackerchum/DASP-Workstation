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
            var signalDefinition = new SignalDefinition(float.Parse(amplitude.Text), float.Parse(frequency.Text), float.Parse(phase.Text), samplingRate);
            _signalHelper.AddSine(signalDefinition);

            sineWavesCmb.Items.Add(signalDefinition.ToString(float.Parse(amplitude.Text), float.Parse(frequency.Text), float.Parse(phase.Text)));
            amplitude.Text = ""; frequency.Text = ""; phase.Text = "";
        }


        private void plotSignalBtn_Click(object sender, RoutedEventArgs e)
        {
            var signalPlotter = new SignalPlotter();
            WriteableBitmap signalBmp = BitmapFactory.New(1270, 202);
            Image waveform = new Image();

            var signal = _signalGenerator.GenerateSignal(_signalHelper.GetValues());
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
