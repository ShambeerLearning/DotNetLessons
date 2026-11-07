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
using System.Media;
using Zvonok.Support;

namespace Zvonok
{
    /// <summary>
    /// Логика взаимодействия для ZvonokPage.xaml
    /// </summary>
    public partial class ZvonokPage : Page
    {
        Status status = new Status();
        SoundFunctions soundsFunc = new SoundFunctions();
        SoundPaths paths = new SoundPaths();
        private void UpStatus()
        {
            status.CheckStatus();
            TextOption.Text = status.statusText;
        }
        public ZvonokPage()
        {
            InitializeComponent();
            UpStatus();
        }

        private void BtnStop_Click(object sender, RoutedEventArgs e)
        {
            status.statusWork = "off";
            UpStatus();
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            status.statusWork = "on";
            UpStatus();
        }

        private void BtnAttention_Click(object sender, RoutedEventArgs e)
        {
            status.statusWork = "attention";
            UpStatus();
            if (status.statusWork == "attention")
            {
                try
                {
                    soundsFunc.AttentionPlay(paths.GetPaths(1), status.statusWork);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BtnSaveTime_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnTimeDefault_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSound_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                soundsFunc.PlayOn(paths.GetPaths(0));
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BtnStopSoundAll_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                soundsFunc.PlayOff();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BtnAttentionSound_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                soundsFunc.PlayOn(paths.GetPaths(1));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
