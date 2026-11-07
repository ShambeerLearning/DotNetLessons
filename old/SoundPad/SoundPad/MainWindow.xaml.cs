using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Media;
using SoundPad.functions;
using SoundPad.subfunc;

namespace SoundPad
{
    public partial class MainWindow : Window
    {
        SoundsPad soundspad = new SoundsPad();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                switch (button.Name)
                {
                    case "stop":
                        soundspad.play_off();
                        break;
                    case "dobri":
                        soundspad.play_on(SoundPaths.Path1);
                        break;
                    case "vibe":
                        soundspad.play_on(SoundPaths.Path2);
                        break;
                    case "ogo":
                        soundspad.play_on(SoundPaths.Path3);
                        break;
                    case "superme":
                        soundspad.play_on(SoundPaths.Path4);
                        break;
                    case "imsucking":
                        soundspad.play_on(SoundPaths.Path5);
                        break;
                    default:
                        MessageBox.Show("Звук не выбран!");
                        break;
                }
            }
        }
        private void VolumeControl_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            
        }
    }
}