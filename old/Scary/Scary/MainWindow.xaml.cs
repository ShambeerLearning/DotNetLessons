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

namespace Scary
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            int a = 0;
            InitializeComponent();
            if (a == 1)
            {
                Test.Visibility = Visibility.Visible;
            } else if(a == 0)
            {
                Test.Visibility= Visibility.Hidden;
            }
        }

        private void BtnDestroy_Click(object sender, RoutedEventArgs e)
        {
            MetodDestroyer metodDestroyer = new MetodDestroyer();
            metodDestroyer.Open_Window();
        }

        private void Test_Click(object sender, RoutedEventArgs e)
        {
            MetodDestroyer metodDestroyer = new MetodDestroyer();
        }
    }
}
