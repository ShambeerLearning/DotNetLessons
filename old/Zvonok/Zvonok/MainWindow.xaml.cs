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
using ShambersMicroServicesMultiSoft.ZvonokSoft;

namespace ShambersMicroServicesMultiSoft
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnZvonki_Click(object sender, RoutedEventArgs e)
        {
            ShambersMicroServicesMultiSoft.ZvonokSoft.Zvonok zvonokSoft = new ShambersMicroServicesMultiSoft.ZvonokSoft.Zvonok();
            zvonokSoft.Show();
        }
    }
}
