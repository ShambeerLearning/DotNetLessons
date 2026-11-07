using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SoundPad.functions
{
    class SoundsPad
    {
       
        public void play_on(string SoundPath)
        {
            try
            {
                SoundPlayer player = new SoundPlayer(SoundPath);
                player.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void play_off()
        {
            try
            {
                SoundPlayer player = new SoundPlayer();
                player.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
