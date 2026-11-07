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
using System.Windows.Shapes;
using ShambersMicroServicesMultiSoft.Support;
using ShambersMicroServicesMultiSoft.

namespace ShambersMicroServicesMultiSoft.ZvonokSoft
{
    /// <summary>
    /// Логика взаимодействия для Zvonok.xaml
    /// </summary>
    public partial class Zvonok : Window
    {
        Status status = new Status();
        SoundFunctions soundsFunc = new SoundFunctions();
        SoundPaths paths = new SoundPaths();
        private void UpStatus()
        {
            status.CheckStatus();
            TextOption.Text = status.statusText;
        }
        public Zvonok()
        {
            InitializeComponent();
            UpStatus();
        }
    }
}
