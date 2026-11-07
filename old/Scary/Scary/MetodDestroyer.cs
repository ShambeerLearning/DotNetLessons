using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Scary
{
    internal class MetodDestroyer
    {
        public void Open_Window()
        {
            var pizdec = new MainWindow();
            pizdec.Show();
            Open_Cmd();
            Open_Cmd();
            Message_Desrtoy();
            Open_Window();
        }

        private void Open_Cmd()
        {
            System.Diagnostics.Process.Start("CMD.exe");
        }

        private void Message_Desrtoy()
        {
            MessageBox.Show("OH SHIT BABY, YOUR PC IS VERY HOT DAMN");
        }
    }
}
